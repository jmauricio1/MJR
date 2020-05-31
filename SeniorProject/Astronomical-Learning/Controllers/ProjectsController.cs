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
        public ActionResult CreateProject(Project model)
        {

            model.AcceptState = false;
            model.PostDate = DateTime.Now;
            model.Username = User.Identity.GetUserName();

            Debug.WriteLine(model.Username);
            Debug.WriteLine(model.Title);
            Debug.WriteLine(model.Description);
            Debug.WriteLine(model.PostDate);
            Debug.WriteLine(model.AcceptState);

           
                db.Projects.Add(model);
                db.SaveChanges();
            

            

            return RedirectToAction("ProjectList");
        }
    }
}