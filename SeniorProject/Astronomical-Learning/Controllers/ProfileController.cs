using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
//using Astronomical_Learning.TempDAL;

namespace Astronomical_Learning.Controllers
{
    public class ProfileController : Controller
    {
        private ALContext db = new ALContext();
        //private TempContext db = new TempContext();

        // GET: Profile
        public ActionResult ProfilePage(string changedUsername)
        {

            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId); ;

            try
            {
                ViewBag.UserName = user.UserName;
            }
            catch
            {
                return RedirectToAction("CustomError", "Home", new { errorName = "Profile not found.", errorMessage = "This profile does not exist please try logging in with a different account." });

            }



            
            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = StringInfo.GetNextTextElement(user.LastName, 0);
            ViewBag.State = user.StateProvince;
            ViewBag.Country = user.Country;
            ViewBag.Path = user.AvatarPath.Path.ToString();

            LevelUpdate(userId);

            int? badgeID = user.LevelID;
            ViewBag.Badge = db.UserLevels.Find(badgeID).BadgePath.ToString();
            ViewBag.Level = db.UserLevels.Find(badgeID).LevelName.ToString();

            string temp = "";
            if (user.Bio != null)
            {
                temp = user.Bio.ToString();
            }
            ViewBag.Description = temp;
            ViewBag.ChangedUsername = changedUsername;


            List<UserComment> comments = db.UserComments.Where(x => x.Username == User.Identity.Name && x.AcceptState == true && x.ReportCount < 5).ToList();


            if(user.AspNetRoles.Count == 0)
            {
                UserManager.AddToRole(user.Id, "User");
                db.SaveChanges();
            }

            ViewBag.Role = user.AspNetRoles.ElementAt(0).Id;

            if ((user.AccountScore) >= 0 && (user.AccountScore < 50))
            {
                int nextLevelXP = 50 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Astronaut In Training";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";

            }
            else if ((user.AccountScore >= 50) && (user.AccountScore < 100))
            {
                int nextLevelXP = 100 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Astronaut";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 100) && (user.AccountScore < 150))
            {
                int nextLevelXP = 150 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Star Charter";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 150) && (user.AccountScore < 200))
            {
                int nextLevelXP = 200 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Orbit Breaker";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 200) && (user.AccountScore < 250))
            {
                int nextLevelXP = 250 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Space Walker";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 250) && (user.AccountScore < 300))
            {
                int nextLevelXP = 300 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Shooting Star";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 300) && (user.AccountScore < 350))
            {
                int nextLevelXP = 350 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Superstar";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 350) && (user.AccountScore < 400))
            {
                int nextLevelXP = 400 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Supernova";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if ((user.AccountScore >= 400) && (user.AccountScore < 450))
            {
                int nextLevelXP = 450 - user.AccountScore;
                ViewBag.NextLevelXP = nextLevelXP;

                ViewBag.NextLevel = "Celestial Being";

                int nextLevelPct = 100 - (nextLevelXP * 2);
                ViewBag.NextLevelPct = nextLevelPct + "%";
            }
            else if (user.AccountScore >= 450)
            {
                ViewBag.NextLevelXP = -1;
                ViewBag.NextLevel = "You're maximum rank!";
            }


            return View(comments);
        }

        public ActionResult UserProfile(string id)
        {
            var user = db.AspNetUsers.Find(id);

            try
            {
                ViewBag.UserName = user.UserName;
            }
            catch
            {
                return RedirectToAction("CustomError", "Home", new { errorName = "Profile not found.", errorMessage = "This profile does not exist please try logging in with a different account." });

            }

            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = StringInfo.GetNextTextElement(user.LastName, 0);
            ViewBag.State = user.StateProvince;
            ViewBag.Country = user.Country;
            ViewBag.Path = user.AvatarPath.Path.ToString();

            int? badgeID = user.LevelID;
            ViewBag.Badge = db.UserLevels.Find(badgeID).BadgePath.ToString();
            ViewBag.Level = db.UserLevels.Find(badgeID).LevelName.ToString();

            string temp = "";
            if (user.Bio != null)
            {
                temp = user.Bio.ToString();
            }
            ViewBag.Description = temp;

            List<UserComment> comments = db.UserComments.Where(x => x.Username == user.UserName && x.AcceptState == true && x.ReportCount < 5).ToList();
            
            return View(comments);
        }

        public void LevelUpdate(string userID)
        {
            var user = db.AspNetUsers.Find(userID);
            if((user.AccountScore) >= 0 && (user.AccountScore < 50))
            {
                user.LevelID = 1;
            }
            else if ((user.AccountScore >= 50) && (user.AccountScore < 100))
            {
                user.LevelID = 2;
            }
            else if ((user.AccountScore >= 100) && (user.AccountScore < 150))
            {
                user.LevelID = 3;
            }
            else if ((user.AccountScore >= 150) && (user.AccountScore < 200))
            {
                user.LevelID = 4;
            }
            else if ((user.AccountScore >= 200) && (user.AccountScore < 250))
            {
                user.LevelID = 5;
            }
            else if ((user.AccountScore >= 250) && (user.AccountScore < 300))
            {
                user.LevelID = 6;
            }
            else if ((user.AccountScore >= 300) && (user.AccountScore < 350))
            {
                user.LevelID = 7;
            }
            else if ((user.AccountScore >= 350) && (user.AccountScore < 400))
            {
                user.LevelID = 8;
            }
            else if ((user.AccountScore >= 400) && (user.AccountScore < 450))
            {
                user.LevelID = 9;
            }
            else if (user.AccountScore >= 450)
            {
                user.LevelID = 10;
            }
            db.SaveChanges();
        }

        [HttpPost]
        public void DeleteComment(int? commentId)
        {
            if(commentId != null) { 
                UserComment comment = db.UserComments.Where(x => x.Id == commentId).FirstOrDefault();

                if(comment != null) { 
                    db.UserComments.Remove(comment);
                    db.SaveChanges();
                }
            }
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public void CalculateBadgePercent()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);


        }
    }
}