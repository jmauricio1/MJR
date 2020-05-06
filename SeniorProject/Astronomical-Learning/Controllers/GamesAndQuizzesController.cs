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
    }
}