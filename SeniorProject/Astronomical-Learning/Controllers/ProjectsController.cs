using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;

namespace Astronomical_Learning.Controllers
{
    public class ProjectsController : Controller
    {

        private ALContext db = new ALContext();

        // GET: Projects
        public ActionResult ProjectList()
        {
            var allProjects = db.Projects.Where(x => x.AcceptState == true);
            return View(allProjects);
        }

        [Authorize(Roles = "User,Administrator,Super Administrator")]
        public ActionResult CreateProject()
        {
            return View();
        }

        [Authorize(Roles = "User,Administrator,Super Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject( Project model)
        {

            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);



            model.AcceptState = false;
            model.PostDate = DateTime.Now;
            model.UserName = user.UserName;


            if (ModelState.IsValid)
            {
                db.Projects.Add(model);
                db.SaveChanges();
            }
               
            

            

            return RedirectToAction("ProjectList");
        }
    }
}