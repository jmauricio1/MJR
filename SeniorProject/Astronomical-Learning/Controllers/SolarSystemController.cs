using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class SolarSystemController : Controller
    {
        // GET: SolarSystem
        public ActionResult Moon_Information()
        {
            return View();
        }

        public ActionResult Sun_Information()
        {
            return View();
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
    }
}