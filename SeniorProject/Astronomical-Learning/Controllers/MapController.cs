using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult InteractiveMap()
        {
            return View();
        }
    }
}