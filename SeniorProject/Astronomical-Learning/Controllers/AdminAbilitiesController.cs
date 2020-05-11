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


        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult ReviewComments()
        {


            var unreviewdComments = db.UserComments.Where(x => x.AcceptState == false);

            return View(unreviewdComments);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator,Super Administrator")]
        public void AcceptComment(int? commentId)
        {
            if (commentId != null)
            {
                UserComment comment = db.UserComments.Where(x => x.Id == commentId).FirstOrDefault();

                if (comment != null)
                {
                    comment.AcceptState = true;

                    var userID = User.Identity.GetUserId();
                    var user = db.AspNetUsers.Find(userID);
                    user.AccountScore = (int)user.AccountScore + 5;

                    db.SaveChanges();
                }
            }
        }


        [HttpPost]
        [Authorize(Roles = "Administrator,Super Administrator")]
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


        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult AllUsers()
        {


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
        [Authorize(Roles = "Administrator,Super Administrator")]
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


        [Authorize(Roles = "Administrator,Super Administrator")]
        public ActionResult BannedUsers()
        {


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
        [Authorize(Roles = "Administrator,Super Administrator")]
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


        [Authorize(Roles = "Administrator,Super Administrator")]
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
        [Authorize(Roles = "Administrator,Super Administrator")]
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




        #region Countries List
        public List<string> GetCountries(ref List<string> temp)
        {
            //A11
            temp.Add("Afghanistan");
            temp.Add("Albania");
            temp.Add("Algeria");
            temp.Add("Andorra");
            temp.Add("Angola");
            temp.Add("Antigua and Barbuda");
            temp.Add("Argentina");
            temp.Add("Armenia");
            temp.Add("Australia");
            temp.Add("Austria");
            temp.Add("Azerbaijan");

            //B19
            temp.Add("Bahamas, The");
            temp.Add("Bahrain");
            temp.Add("Bangladesh");
            temp.Add("Barbados");
            temp.Add("Belarus");
            temp.Add("Belgium");
            temp.Add("Belize");
            temp.Add("Benin(Dahomey)");
            temp.Add("Bermuda");
            temp.Add("Bhutan");
            temp.Add("Bolivia");
            temp.Add("Bosnia and Herzegovina");
            temp.Add("Botswana");
            temp.Add("Brazil");
            temp.Add("Brunei");
            temp.Add("Bulgaria");
            temp.Add("Burkina Faso");
            temp.Add("Burma");
            temp.Add("Burundi");

            //C17
            temp.Add("Cabo Verde");
            temp.Add("Cambodia");
            temp.Add("Cameroon");
            temp.Add("Canada");
            temp.Add("Cayman Islands, The");
            temp.Add("Central African Republic");
            temp.Add("Chad");
            temp.Add("Chile");
            temp.Add("China");
            temp.Add("Colombia");
            temp.Add("Comoros");
            temp.Add("Costa Rica");
            temp.Add("Cote d’Ivoire(Ivory Coast)");
            temp.Add("Croatia");
            temp.Add("Cuba");
            temp.Add("Cyprus");
            temp.Add("Czechia");

            //D5
            temp.Add("Democratic Republic of the Congo");
            temp.Add("Denmark");
            temp.Add("Djibouti");
            temp.Add("Dominica");
            temp.Add("Dominican Republic");

            //E9
            temp.Add("Ecuador");
            temp.Add("Egypt");
            temp.Add("El Salvador");
            temp.Add("Equatorial Guinea");
            temp.Add("Eritrea");
            temp.Add("Estonia");
            temp.Add("Eswatini");
            temp.Add("Ethiopia");

            //F3
            temp.Add("Faroe Islands (Isls Malvinas)");
            temp.Add("Fiji");
            temp.Add("Finland");
            temp.Add("France");
            temp.Add("French Polynesia");

            //G12
            temp.Add("Gabon");
            temp.Add("Gambia, The");
            temp.Add("Georgia");
            temp.Add("Germany");
            temp.Add("Ghana");
            temp.Add("Greece");
            temp.Add("Greenland");
            temp.Add("Grenada");
            temp.Add("Guatemala");
            temp.Add("Guinea");
            temp.Add("Guinea - Bissau");
            temp.Add("Guyana");

            //H4
            temp.Add("Haiti");
            temp.Add("Holy See");
            temp.Add("Honduras");
            temp.Add("Hungary");

            //I8
            temp.Add("Iceland");
            temp.Add("India");
            temp.Add("Indonesia");
            temp.Add("Iran");
            temp.Add("Iraq");
            temp.Add("Ireland");
            temp.Add("Israel");
            temp.Add("Italy");

            //J3
            temp.Add("Jamaica");
            temp.Add("Japan");
            temp.Add("Jordan");

            //K7
            temp.Add("Kazakhstan");
            temp.Add("Kenya");
            temp.Add("Kiribati");
            temp.Add("South Korea");
            temp.Add("Kosovo");
            temp.Add("Kuwait");
            temp.Add("Kyrgyzstan");

            //L
            temp.Add("Laos");
            temp.Add("Latvia");
            temp.Add("Lebanon");
            temp.Add("Lesotho");
            temp.Add("Liberia");
            temp.Add("Libya");
            temp.Add("Liechtenstein");
            temp.Add("Lithuania");
            temp.Add("Luxembourg");

            //M
            temp.Add("Madagascar");
            temp.Add("Malawi");
            temp.Add("Malaysia");
            temp.Add("Maldives");
            temp.Add("Mali");
            temp.Add("Malta");
            temp.Add("Marshall Islands");
            temp.Add("Mauritania");
            temp.Add("Mauritius");
            temp.Add("Mexico");
            temp.Add("Micronesia");
            temp.Add("Moldova");
            temp.Add("Monaco");
            temp.Add("Mongolia");
            temp.Add("Montenegro");
            temp.Add("Montserrat");
            temp.Add("Morocco");
            temp.Add("Mozambique");

            //N
            temp.Add("Namibia");
            temp.Add("Nauru");
            temp.Add("Nepal");
            temp.Add("Netherlands, The");
            temp.Add("New Caledonia");
            temp.Add("New Zealand");
            temp.Add("Nicaragua");
            temp.Add("Niger");
            temp.Add("Nigeria");
            temp.Add("North Macedonia");
            temp.Add("Norway");

            //O
            temp.Add("Oman");

            //P
            temp.Add("Pakistan");
            temp.Add("Palau");
            temp.Add("Panama");
            temp.Add("Papua New Guinea");
            temp.Add("Paraguay");
            temp.Add("Peru");
            temp.Add("Philippines");
            temp.Add("Poland");
            temp.Add("Portugal");
            temp.Add("Puerto Rico");

            //Q
            temp.Add("Qatar");

            //R
            temp.Add("Romania");
            temp.Add("Russia");
            temp.Add("Rwanda");

            //S26
            temp.Add("Saint Helena, Ascension, and Tristan da Cunha");
            temp.Add("Saint Kitts and Nevis");
            temp.Add("Saint Lucia");
            temp.Add("Saint Vincent and the Grenadines");
            temp.Add("Samoa");
            temp.Add("San Marino");
            temp.Add("Sao Tome and Principe");
            temp.Add("Saudi Arabia");
            temp.Add("Senegal");
            temp.Add("Serbia");
            temp.Add("Seychelles");
            temp.Add("SierraLeone");
            temp.Add("Singapore");
            temp.Add("Slovakia");
            temp.Add("Slovenia");
            temp.Add("Solomon Islands, The");
            temp.Add("Somalia");
            temp.Add("South Africa");
            temp.Add("South Sudan");
            temp.Add("Spain");
            temp.Add("Sri Lanka");
            temp.Add("Sudan");
            temp.Add("Suriname");
            temp.Add("Sweden");
            temp.Add("Switzerland");
            temp.Add("Syria");

            //T
            temp.Add("Taiwan");
            temp.Add("Tajikistan");
            temp.Add("Tanzania");
            temp.Add("Thailand");
            temp.Add("Timor - Leste");
            temp.Add("Togo");
            temp.Add("Tonga");
            temp.Add("Trinidad and Tobago");
            temp.Add("Tunisia");
            temp.Add("Turkey");
            temp.Add("Turkmenistan");
            temp.Add("Tuvalu");

            //U7
            temp.Add("Uganda");
            temp.Add("Ukraine");
            temp.Add("United Arab Emirates, The");
            temp.Add("United Kingdom, The");
            temp.Add("United States, The");
            temp.Add("Uruguay");
            temp.Add("Uzbekistan");

            //V3
            temp.Add("Vanuatu");
            temp.Add("Venezuela");
            temp.Add("Vietnam");

            //Y1
            temp.Add("Yemen");

            //Z2
            temp.Add("Zambia");
            temp.Add("Zimbabwe");


            Debug.WriteLine(temp[125] + temp[125].Count());
            return temp;
        }
        #endregion

        List<string> countryList = new List<string>();




        // GET: /Account/Register
        [AllowAnonymous]
        [Authorize(Roles = "Super Administrator")]
        public ActionResult AdminCreate()
        {

            countryList = GetCountries(ref countryList);

            ViewBag.CountriesList = countryList;
         

            return View("AdminCreate");
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Super Administrator")]
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









        [Authorize(Roles = "Super Administrator")]
        public ActionResult AllAdmin()
        {

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
        [Authorize(Roles = "Super Administrator")]
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

        [Authorize(Roles = "Super Administrator")]
        public ActionResult BannedAdmin()
        {

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

        [Authorize(Roles = "Super Administrator")]
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



        [Authorize(Roles = "Super Administrator")]
        public ActionResult EditAdminBan(string id)
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
        [Authorize(Roles = "Super Administrator")]
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

            model.DisplayCount = 0;
            model.AdminUsername = user.UserName;
            model.DateSubmitted = DateTime.Now;

            bool added = false;
            if (ModelState.IsValid)
            {
                db.FactOfTheDays.Add(model);
                db.SaveChanges();
                added = true;
            }
            ViewBag.Added = added;
            ViewBag.FactList = db.FactOfTheDays.Where(m => m.DisplayCount >= 0);
            return View();
        }


    }
}