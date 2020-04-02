using Astronomical_Learning.Models;
using Astronomical_Learning.Models.Launches;
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
                launch.launchSuccess = (string)data[i]["launch_success"];
                launch.flightNum = (int)data[i]["flight_number"];
                list.Add(launch);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LaunchDetails(int? id)
        {
            string json = SendRequest("https://api.spacexdata.com/v3/launches");
            JArray data = JArray.Parse(json);

            MainLaunchInformation mainInfo = new MainLaunchInformation();

            id--;
            mainInfo.flightNum = (int)data[id]["flight_number"];
            mainInfo.missName = (string)data[id]["mission_name"];
            var tempID = data[id]["mission_id"];
            if (tempID.Count() == 0)
            {
                mainInfo.missID = "No ID available";
            }
            else
            {
                mainInfo.missID = (string)data[id]["mission_id"][0];
            }

            mainInfo.launchSuccess = (string)data[id]["launch_success"];

            mainInfo.launchYear = (int)data[id]["launch_year"];
            mainInfo.launchDateUnix = (string)data[id]["launch_date_unix"];
            mainInfo.launchDateUTC = (string)data[id]["launch_date_utc"];
            mainInfo.launchDateLocal = (string)data[id]["launch_date_local"];
            mainInfo.tent = (string)data[id]["is_tentative"];
            mainInfo.tentMaxPrecise = (string)data[id]["tentative_max_precision"];

            SingleLaunchViewModel viewModel = new SingleLaunchViewModel(mainInfo);
            return View(viewModel);
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