using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;

namespace Astronomical_Learning.Controllers
{
    public class AdminAbilitiesController : Controller
    {

        private ALContext db = new ALContext();


        // GET: AdminAbilities
        public ActionResult ReviewComments()
        {

            if(User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US")
            {
                return Redirect("~/Home/Index");
            }
            

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


            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US")
            {
                return Redirect("~/Home/Index");
            }



            var allUsers = db.AspNetUsers.ToArray();


            List<DAL.AspNetUser> regularUsers = new List<DAL.AspNetUser>();


            for (int i = 0; i < allUsers.Length; i++)
            {
                if (allUsers[i].AspNetRoles.ElementAt(0).Id == "US")
                {
                    regularUsers.Add(allUsers[i]);
                }
            }


            return View(regularUsers);

        }

        [HttpPost]
        public ActionResult AllUsers(string searchInput)
        {



            var searchedUsers = db.AspNetUsers.Where(x => x.UserName.Contains(searchInput)).ToArray();

            List<DAL.AspNetUser> regularUsers = new List<DAL.AspNetUser>();


            for(int i = 0; i < searchedUsers.Length; i++)
            {
                if(searchedUsers[i].AspNetRoles.ElementAt(0).Id == "US")
                {
                    regularUsers.Add(searchedUsers[i]);
                }
            }


            return View(regularUsers);
        }

        public ActionResult BannedUsers()
        {



            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US")
            {
                return Redirect("~/Home/Index");
            }


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


            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US")
            {
                return Redirect("~/Home/Index");
            }


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

        public string checkUserRole()
        {
            string userId = User.Identity.GetUserId();
            DAL.AspNetUser user = db.AspNetUsers.Find(userId);
            string role = user.AspNetRoles.ElementAt(0).Id;

            return role;
        }

    }
}