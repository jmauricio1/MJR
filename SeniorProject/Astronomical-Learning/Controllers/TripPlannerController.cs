using Astronomical_Learning.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class TripPlannerController : Controller
    {
        private ALContext db = new ALContext();

        // GET: TripPlanner
        public ActionResult OurSolarSystem()
        {
            return View();
        }

        public JsonResult States(string Location)
        {
            List<string> LocationList = new List<string>();

            switch (Location)
            {
                case "Sun":
                    for(int i = 1; i < 10; i++)
                    {
                        if (db.Locations.Select(x => x.LocationName.Equals(Location)).FirstOrDefault())
                        {

                        }
                        else
                        {
                            LocationList.Add(db.Locations.Select(x => x.LocationName).Where(x => x.Id == 1));
                        }
                    }
                    break;

                case "Mercury":
                   
                    break;
            }

            return Json(LocationList);
        }
    }
}