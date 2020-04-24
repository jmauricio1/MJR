using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class OuterSystemController : Controller
    {
        private ALContext db = new ALContext();
        // GET: OuterSystem
        public ActionResult MilkyWay_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/OuterSystem/MilkyWay_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/OuterSystem/SubmitComment";

            return View(comments);
        }

        public ActionResult Andromeda_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/OuterSystem/Andromeda_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/OuterSystem/SubmitComment";

            return View(comments);
        }
        public ActionResult Stars_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/OuterSystem/Stars_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();
            ViewBag.URL = "/OuterSystem/SubmitComment";

            return View(comments);
        }

        public ActionResult Stars_Constellations()
        {
            return View();
        }

        public ActionResult Interstellar_Space()
        {
            return View();
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
    }
}