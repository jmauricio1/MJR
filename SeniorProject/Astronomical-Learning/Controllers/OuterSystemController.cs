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
        public ActionResult Stars_Information()
        {
            return View();
        }

        public ActionResult Stars_Constellations()
        {
            return View();
        }

        public ActionResult Interstellar_Space()
        {
            return View();
        }
        //
    }
}