using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Astronomical_Learning.Controllers
{
    public class SolarSystemController : Controller
    {
        private ALContext db = new ALContext();


        // GET: SolarSystem
        public ActionResult Moon_Information()
        {
            //Retrieves and displays comment section
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Moon_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            //incremeent the ViewCount of the page in the database
            var viewCount = db.ViewDatas.Where(x => x.PageName == "Moon");

            foreach (ViewData item in viewCount)
            {
                item.ViewCount += 1;
            }

            db.SaveChanges();

            return View(comments);
        }

        public ActionResult Sun_Information()
        {
            //Retrieves and displays comment section
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Sun_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            //incremeent the ViewCount of the page in the database
            var viewCount = db.ViewDatas.Where(x => x.PageName == "Sun");

            foreach (ViewData item in viewCount)
            {
                item.ViewCount += 1;
            }

            db.SaveChanges();

            return View(comments) ;
        }

        public ActionResult SpaceDebris_Information()
        {
            //Retrieves and displays comment section
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/SpaceDebris_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            //incremeent the ViewCount of the page in the database
            var viewCount = db.ViewDatas.Where(x => x.PageName == "SpaceDebris");
            
            foreach(ViewData item in viewCount)
            {
                item.ViewCount += 1;
            }
            
            db.SaveChanges();

            return View(comments);
        }

        public ActionResult Our_Planets()
        {
            //Retrieves and displays comment section
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Our_Planets" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            //incremeent the ViewCount of the page in the database
            var viewCount = db.ViewDatas.Where(x => x.PageName == "Planets");

            foreach (ViewData item in viewCount)
            {
                item.ViewCount += 1;
            }

            db.SaveChanges();

            return View(comments);
        }
        public ActionResult KuiperBelt()
        {
            return View();
        }

        public ActionResult Mars_Research()
        {
            //Retrieves and displays comment section
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Mars_Research" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            //incremeent the ViewCount of the page in the database
            var viewCount = db.ViewDatas.Where(x => x.PageName == "Mars");

            foreach (ViewData item in viewCount)
            {
                item.ViewCount += 1;
            }

            db.SaveChanges();

            return View(comments);
        }

        [HttpPost]
        public JsonResult SubmitComment([Bind(Exclude = "Id, PostDate, AcceptState")] UserComment comment)
        {
            /* Make sure the Model passed in is in a valid state before doing anything with it */
            if (ModelState.IsValid)
            {
                /* Set the rest of the information of the comment */
                comment.Username = User.Identity.Name;
                comment.PostDate = DateTime.Now;
                comment.AcceptState = false;
                comment.ReportCount = 0;

                /* Add the comment to the UserComments table and save the changes to the database */
                db.UserComments.Add(comment);
                db.SaveChanges();
            }

            return Json(ModelState.IsValid, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ReportComment(int? id, string returnUrl)
        {
            if (id != null)
            {
                UserComment originalComment = db.UserComments.Where(x => x.Id == id).FirstOrDefault();

                //Increment the report count of pages within the database
                if (originalComment != null)
                {
                    UserComment newComment = originalComment;
                    newComment.ReportCount += 1;
                    db.Entry(originalComment).CurrentValues.SetValues(newComment);
                    db.SaveChanges();
                }
            };

            return RedirectToAction(returnUrl);
        }
    }
}