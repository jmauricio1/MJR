using Astronomical_Learning.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class GamesAndQuizzesController : Controller
    {
        // GET: GamesAndQuizzes
        public ActionResult QuizSelection()
        {
            return View();
        }

        public ActionResult Quiz_1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Q1Score(int? a1, int? a2, int? a3, int? a4, int? a5,
            int? a6, int? a7, int? a8, int? a9, int? a10)
        {
            List<string> results = new List<string>();

            results.Add(AnswerChecker(a1, 2));
            results.Add(AnswerChecker(a2, 1));
            results.Add(AnswerChecker(a3, 4));
            results.Add(AnswerChecker(a4, 3));
            results.Add(AnswerChecker(a5, 2));
            results.Add(AnswerChecker(a6, 1));
            results.Add(AnswerChecker(a7, 1));
            results.Add(AnswerChecker(a8, 2));
            results.Add(AnswerChecker(a9, 2));
            results.Add(AnswerChecker(a10, 3));

            if (User.IsInRole("User") || User.IsInRole("Administrator") || User.IsInRole("Super Administrator"))
            {
                int correctCount = 0;
                for(int i = 0; i < results.Count; i++)
                {
                    if(results[i] == "Correct")
                    {
                        correctCount++;
                    }
                }
                int newScore = correctCount * 3;
                Debug.WriteLine("Quiz Score : " + newScore);
                ApplyScore(newScore);
            }

            ViewBag.Results = results;
            return View();
        }

        public string AnswerChecker(int? input, int? answer)
        {
            if (input == answer)
                return "Correct";
            else
                return "Incorrect";
        }

        private ALContext db = new ALContext();
        public void ApplyScore(int score)
        {
            var userID = User.Identity.GetUserId();
            int toAdd = 0;
            if (db.UserQuizScores.Where(m => m.UserID == userID && m.QuizID == 1).Count() > 0)
            {
                var userScoreID = db.UserQuizScores.Where(s => s.QuizID == 1 && s.UserID == userID).First();
                //var current = db.UserQuizScores.Find(userScoreID);
                
                if(score > userScoreID.HighestScore)
                {
                    toAdd = score - userScoreID.HighestScore;
                    userScoreID.HighestScore = score;
                }
            }
            else
            {
                UserQuizScore userScore = new UserQuizScore();
                userScore.UserID = userID;
                userScore.QuizID = 1;
                userScore.HighestScore = score;

                /*
                FakeUserQuizScore userScore = new FakeUserQuizScore();
                userScore.QuizID = 1;
                userScore.UserID = userID;
                userScore.HighestScore = score;
                */

                toAdd = score;

                db.UserQuizScores.Add(userScore);
                db.SaveChanges();

            }

            var user = db.AspNetUsers.Find(userID);
            int temp = user.AccountScore;
            user.AccountScore = temp + toAdd;

            db.SaveChanges();
        }
    }

    public class FakeUserQuizScore
    {
        public int QuizID;
        public string UserID;
        public int HighestScore;
    }
}