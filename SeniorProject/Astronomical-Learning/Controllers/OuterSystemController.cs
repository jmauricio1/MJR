using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class OuterSystemController : Controller
    {
        // GET: OuterSystem
        public ActionResult MilkyWay_Information()
        {
            return View();
        }

        public ActionResult Andromeda_Information()
        {
            return View();
        }

        public ActionResult SpaceDebris_Information()
        {
            return View();
        }
    }
}