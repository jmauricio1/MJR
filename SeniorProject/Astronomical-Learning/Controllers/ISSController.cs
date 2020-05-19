using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class ISSController : Controller
    {
        // GET: ISS
        public ActionResult InternationalSpaceStation()
        {
            ViewBag.AzureValue = ConfigurationManager.AppSettings["TestAppSetting"];
            return View();
        }
    }
}