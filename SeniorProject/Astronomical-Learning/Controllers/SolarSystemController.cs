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
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Moon_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            return View(comments);
        }

        public ActionResult Sun_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Sun_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            return View(comments) ;
        }

        public ActionResult SpaceDebris_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/SpaceDebris_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            return View(comments);
        }

        public ActionResult Our_Planets()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Our_Planets" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

            return View(comments);
        }
        public ActionResult KuiperBelt()
        {
            return View();
        }

        public ActionResult Mars_Research()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Mars_Research" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/SolarSystem/SubmitComment";

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
                comment.AcceptState = true;
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