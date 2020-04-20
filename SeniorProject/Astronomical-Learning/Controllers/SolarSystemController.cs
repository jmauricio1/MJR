using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult Sun_Information()
        {
            List<UserComment> comments = db.UserComments.Where(x => x.PageFrom == "/SolarSystem/Sun_Information" && x.AcceptState == true && x.ReportCount < 5).ToList();

            return View(comments) ;
        }

        public ActionResult SpaceDebris_Information()
        {
            return View();
        }

        public ActionResult Our_Planets()
        {
            return View();
        }
        public ActionResult KuiperBelt()
        {
            return View();
        }

        public ActionResult Mars_Research()
        {
            return View();
        }

        [HttpPost]
        public void SubmitComment(string json)
        {
            var data = JsonConvert.DeserializeObject(json);

            UserComment newComment = new UserComment();

            newComment.Username = User.Identity.Name;
            newComment.PostDate = DateTime.Now;
            newComment.PageFrom = "/SolarSystem/Sun_Information";   //should be data.url
            newComment.AcceptState = true;
            newComment.Comment = "This is a comment that is premade";   //should be data.comment
            newComment.ReportCount = 0;
            
            db.UserComments.Add(newComment);
            db.SaveChanges();
        }
    }
}