using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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


            var allBanned = db.AspNetUsers.Where(x => x.LockoutEndDateUtc.HasValue).ToArray();

            List<DAL.AspNetUser> bannedUsers = new List<DAL.AspNetUser>();


            for (int i = 0; i < allBanned.Length; i++)
            {
                if (allBanned[i].AspNetRoles.ElementAt(0).Id == "US")
                {
                    bannedUsers.Add(allBanned[i]);
                }
            }

            return View(bannedUsers);
        }

        [HttpPost]
        public ActionResult BannedUsers(string searchInput)
        {
            var searchedUsers = db.AspNetUsers.Where(y => y.LockoutEndDateUtc.HasValue).Where(x => x.UserName.Contains(searchInput)).ToArray();

            List<DAL.AspNetUser> bannedUsers = new List<DAL.AspNetUser>();


            for (int i = 0; i < searchedUsers.Length; i++)
            {
                if (searchedUsers[i].AspNetRoles.ElementAt(0).Id == "US")
                {
                    bannedUsers.Add(searchedUsers[i]);
                }
            }


            return View(bannedUsers);
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


        //////////////////////////////////////////////
        /// start of super user only abilities
        ////////////////////////////////////////////////////////



        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult AdminCreate()
        {
            
            return View();
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdminCreate(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int x = rand.Next(1, 7);
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Country = model.Country, StateProvince = model.StateProvince, AID = x };
                if (db.AspNetUsers.Any(m => m.UserName == user.UserName) == true)
                {
                    ViewBag.UsernameTaken = "Username already taken or unavailable.";
                    return View();
                }
                else
                {
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        UserManager.AddToRole(user.Id, "Administrator");

                        db.SaveChanges();

                        return RedirectToAction("AdminCreate", "AdminAbilities");
                    }
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }










        public ActionResult AllAdmin()
        {


            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US" || role == "AD")
            {
                return Redirect("~/Home/Index");
            }



            var allUsers = db.AspNetUsers.ToArray();


            List<DAL.AspNetUser> allAdmins = new List<DAL.AspNetUser>();


            for (int i = 0; i < allUsers.Length; i++)
            {
                if (allUsers[i].AspNetRoles.ElementAt(0).Id == "AD")
                {
                    allAdmins.Add(allUsers[i]);
                }
            }


            return View(allAdmins);

        }

        [HttpPost]
        public ActionResult AllAdmin(string searchInput)
        {



            var searchedUsers = db.AspNetUsers.Where(x => x.UserName.Contains(searchInput)).ToArray();

            List<DAL.AspNetUser> searchedAdmins = new List<DAL.AspNetUser>();


            for (int i = 0; i < searchedUsers.Length; i++)
            {
                if (searchedUsers[i].AspNetRoles.ElementAt(0).Id == "AD")
                {
                    searchedAdmins.Add(searchedUsers[i]);
                }
            }


            return View(searchedAdmins);
        }

        public ActionResult BannedAdmin()
        {



            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US"|| role == "AD")
            {
                return Redirect("~/Home/Index");
            }


            var allBanned = db.AspNetUsers.Where(x => x.LockoutEndDateUtc.HasValue).ToArray();

            List<DAL.AspNetUser> bannedAdmins = new List<DAL.AspNetUser>();

            for (int i = 0; i < allBanned.Length; i++)
            {
                if (allBanned[i].AspNetRoles.ElementAt(0).Id == "AD")
                {
                    bannedAdmins.Add(allBanned[i]);
                }
            }

            return View(bannedAdmins);
        }

        [HttpPost]
        public ActionResult BannedAdmin(string searchInput)
        {
            var searchedUsers = db.AspNetUsers.Where(y => y.LockoutEndDateUtc.HasValue).Where(x => x.UserName.Contains(searchInput)).ToArray();

            List<DAL.AspNetUser> bannedAdmins = new List<DAL.AspNetUser>();

            for (int i = 0; i < searchedUsers.Length; i++)
            {
                if (searchedUsers[i].AspNetRoles.ElementAt(0).Id == "AD")
                {
                    bannedAdmins.Add(searchedUsers[i]);
                }
            }


            return View(searchedUsers);
        }




        public ActionResult EditAdminBan(string id)
        {


            if (User.Identity.Name == "")
            {
                return Redirect("~/Home/Index");
            }

            string role = checkUserRole();

            if (role == "US" || role == "AD")
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
        public ActionResult EditAdminBan(DAL.AspNetUser aspNetUser)
        {

            var user = db.AspNetUsers.Find(aspNetUser.Id);
            user.LockoutEndDateUtc = aspNetUser.LockoutEndDateUtc;


            db.SaveChanges();
            //return View(user);


            return RedirectToAction("AllAdmin");
        }













        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult AdminFeatures()
        {
            return View();
        }

        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult InputFact()
        {
            ViewBag.FactList = db.FactOfTheDays.Where(m => m.DisplayCount >= 0);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult InputFact(FactOfTheDay model)
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);

            model.AdminUsername = user.UserName;
            model.DateSubmitted = DateTime.Now;
            model.DisplayCount = 0;

            bool added = false;
            if (ModelState.IsValid)
            {
                db.FactOfTheDays.Add(model);
                db.SaveChanges();
                added = true;
            }
            ViewBag.Added = added;
            return View();
        }


    }
}