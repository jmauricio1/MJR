using AthleteDataTrackerv2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleteDataTrackerv2.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext db = new ApplicationContext();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) 
            {
                
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: StockItems
        public ActionResult Search()
        {
            var athletes = db.Athletes.Where(m => m.ID == 0);
            return View(athletes.ToList());
        }

        [HttpPost]
        public ActionResult Search(string searchInput)
        {
            var athletes = db.Athletes.Where(m => m.LName.Contains(searchInput));
            return View(athletes.ToList());
        }

        public ActionResult AthleteDetails(int?id)
        {

            Athlete athlete = db.Athletes.Find(id);

             var dbresults = db.AthleteResults.Where(m => m.AID == id).ToArray();

            int length = dbresults.Length;

            AthleteResult[] resultList = new AthleteResult[length];

            for(int i = 0; i < length; i++)
            {
                resultList[i] = dbresults[i];
            }

            AthleteDataViewModel model = new AthleteDataViewModel(athlete, resultList);

            return View(model);
        }
    }
}