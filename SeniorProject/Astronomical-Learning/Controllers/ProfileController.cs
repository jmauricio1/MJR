using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;
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
            var user = db.AspNetUsers.Find(userId);

            ViewBag.UserName = user.UserName;
            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = StringInfo.GetNextTextElement(user.LastName, 0);
            ViewBag.State = user.StateProvince;
            ViewBag.Path = user.AvatarPath.Path.ToString();
            string temp = "";
            if (user.Bio != null)
            {
                temp = user.Bio.ToString();
            }
            ViewBag.Description = temp;
            ViewBag.ChangedUsername = changedUsername;


            List<UserComment> comments = db.UserComments.Where(x => x.Username == User.Identity.Name && x.AcceptState == true && x.ReportCount < 5).ToList()
;
            return View(comments);
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
    }
}