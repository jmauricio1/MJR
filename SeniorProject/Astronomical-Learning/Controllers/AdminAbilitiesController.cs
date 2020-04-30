using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;

namespace Astronomical_Learning.Controllers
{
    public class AdminAbilitiesController : Controller
    {

        private ALContext db = new ALContext();


        // GET: AdminAbilities
        public ActionResult ReviewComments()
        {

            var unreviewdComments = db.UserComments.Where(x => x.AcceptState == false);

            return View(unreviewdComments);
        }


        [HttpPost]
        public void AcceptComment(int? commentId)
        {
            if (commentId != null)
            {
                UserComment comment = db.UserComments.Where(x => x.Id == commentId).FirstOrDefault();

                if (comment != null)
                {
                    comment.AcceptState = true;
                    db.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void DeleteComment(int? commentId)
        {
            if (commentId != null)
            {
                UserComment comment = db.UserComments.Where(x => x.Id == commentId).FirstOrDefault();

                if (comment != null)
                {
                    db.UserComments.Remove(comment);
                    db.SaveChanges();
                }
            }
        }


        public ActionResult AllUsers()
        {
            var allUsers = db.AspNetUsers;

            return View(allUsers);
        }

        [HttpPost]
        public ActionResult AllUsers(string searchInput)
        {
            var searchedUsers = db.AspNetUsers.Where(x => x.UserName.Contains(searchInput));
            return View(searchedUsers);
        }

        public ActionResult BannedUsers()
        {
            var bannedUsers = db.AspNetUsers.Where(x => x.LockoutEndDateUtc.HasValue);

            return View(bannedUsers);
        }

        [HttpPost]
        public ActionResult BannedUsers(string searchInput)
        {
            var searchedUsers = db.AspNetUsers.Where(y => y.LockoutEndDateUtc.HasValue).Where(x => x.UserName.Contains(searchInput));
            return View(searchedUsers);
        }



        public ActionResult EditUserBan(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.AID = new SelectList(db.AvatarPaths, "ID", "AvatarName", aspNetUser.AID);
            return View(aspNetUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserBan( DAL.AspNetUser aspNetUser)
        {

            var user = db.AspNetUsers.Find(aspNetUser.Id);
            user.LockoutEndDateUtc = aspNetUser.LockoutEndDateUtc;


                db.SaveChanges();
                //return View(user);
                
            


            return RedirectToAction("AllUsers");
        }

    }
}