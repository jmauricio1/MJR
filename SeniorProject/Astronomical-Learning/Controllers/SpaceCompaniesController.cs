using Astronomical_Learning.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class SpaceCompaniesController : Controller
    {
        // GET: SpaceCompanies
        public ActionResult SpaceX()
        {
            return View();
        }
        public ActionResult SpaceXLaunches()
        {
            return View();
        }
        public JsonResult SpaceXLaunchList()
        {
            string json = SendRequest("https://api.spacexdata.com/v3/launches");

            JArray data = JArray.Parse(json);
            List<Launch> list = new List<Launch>();

            for(int i = 0; i < data.Count; i++)
            {
                Launch launch = new Launch();
                launch.missionName = (string)data[i]["mission_name"];
                launch.missionDate = (string)data[i]["launch_date_utc"];
                list.Add(launch);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NASA()
        {
            return View();
        }

        public ActionResult NASAMissions()
        {
            return View();
        }

        public ActionResult ISS()
        {
            return View();
        }

        private string SendRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            /*            request.Headers.Add("Authorization", "token " + credentials);
                        request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
                        request.Accept = "application/json";*/

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }
}