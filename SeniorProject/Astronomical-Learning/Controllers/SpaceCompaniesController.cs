using Astronomical_Learning.Models;
using Astronomical_Learning.Models.Launches;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            for (int i = 0; i < data.Count; i++)
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

            id--;
            MainLaunchInformation mainInfo = GetMainLaunchInfo(ref data, id);
            RocketInformation rocketInformation = GetRocketInformation(ref data, id);
            FirstStage firstStage = GetFirstStageInformation(ref data, id);
            SecondStage secondStage = GetSecondStageInformation(ref data, id);

            SingleLaunchViewModel viewModel = new SingleLaunchViewModel(mainInfo, rocketInformation, firstStage, secondStage);
            return View(viewModel);
        }

        public MainLaunchInformation GetMainLaunchInfo(ref JArray data, int? id)
        {
            MainLaunchInformation mainInfo = new MainLaunchInformation();

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

            return mainInfo;
        }

        public RocketInformation GetRocketInformation(ref JArray data, int? id)
        {
            RocketInformation rocketInfo = new RocketInformation();

            rocketInfo.rocketID = (string)data[id]["rocket"]["rocket_id"];
            rocketInfo.rocketName = (string)data[id]["rocket"]["rocket_name"];
            rocketInfo.rocketType = (string)data[id]["rocket"]["rocket_type"];

            return rocketInfo;
        }

        public FirstStage GetFirstStageInformation(ref JArray data, int? id)
        {
            FirstStage firstStage = new FirstStage();

            firstStage.coreSerial = (string)data[id]["rocket"]["first_stage"]["cores"][0]["cores_serial"];
            firstStage.flight = (int)data[id]["rocket"]["first_stage"]["cores"][0]["flight"];

            if ((string)data[id]["rocket"]["first_stage"]["cores"][0]["block"] == null)
            {
                firstStage.block = 0;
            }
            else
            {
                firstStage.block = (int)data[id]["rocket"]["first_stage"]["cores"][0]["block"];
            }

            firstStage.gridfins = (string)data[id]["rocket"]["first_stage"]["cores"][0]["gridfins"];
            firstStage.legs = (string)data[id]["rocket"]["first_stage"]["cores"][0]["legs"];
            firstStage.reused = (string)data[id]["rocket"]["first_stage"]["cores"][0]["reused"];

            if((string)data[id]["rocket"]["first_stage"]["cores"][0]["land_success"] == null)
            {
                firstStage.landSuccess = "Null";
            }
            else
            {
                firstStage.landSuccess = (string)data[id]["rocket"]["first_stage"]["cores"][0]["land_success"];
            }

            firstStage.landIntent = (string)data[id]["rocket"]["first_stage"]["cores"][0]["landing_intent"];

            var tempLT = (string)data[id]["rocket"]["first_stage"]["cores"][0]["landing_type"];
            if (tempLT == null)
            {
                firstStage.landType = "No landing type available.";
            }
            else
            {
                firstStage.landType = tempLT;
            }

            var tempLV = (string)data[id]["rocket"]["first_stage"]["cores"][0]["landing_vehicle"];
            if (tempLV == null)
            {
                firstStage.landVeh = "No landing vehicle available";
            }
            else
            {
                firstStage.landVeh = tempLV;
            }

            return firstStage;
        }

        public SecondStage GetSecondStageInformation(ref JArray data, int? id)
        {
            SecondStage secondStage = new SecondStage();

            var temp = data[id]["rocket"]["second_stage"];

            secondStage.block2 = (int)temp["block"];
            List<Payload> payloads = new List<Payload>();
            for(int i = 0; i < data[id]["rocket"]["second_stage"]["payloads"].Count(); i++)
            {
                Payload current = new Payload();

                current.payloadID = (string)temp["payloads"][i]["payload_id"];
                //current.noradID = (int)temp["payloads"][i]["norad_id"][0];
                current.capSerial = (string)temp["payloads"][i]["cap_serial"];
                current.customers = (string)temp["payloads"][i]["customers"][0];
                current.nationality = (string)temp["payloads"][i]["nationality"];
                current.manufac = (string)temp["payloads"][i]["manufacturer"];
                current.payloadType = (string)temp["payloads"][i]["payload_type"];
                current.plmkg = 0.0;
                current.plmlb = 0.0;

                payloads.Add(current);
            }

            for (int j = 0; j < (int)temp["payloads"].Count(); j++){
                payloads[j].orbit = GetPayloadOrbit(ref data, id, j);
            }

            secondStage.payloads = payloads;

            return secondStage;
        }

        public Orbit GetPayloadOrbit(ref JArray data, int? id, int num)
        {
            Orbit orbit = new Orbit();

            orbit.orbit = (string)data[id]["rocket"]["second_stage"]["payloads"][num]["orbit"];
            var temp = data[id]["rocket"]["second_stage"]["payloads"][num]["orbit_params"];

            orbit.refSys = (string)temp["reference_sysytem"];
            orbit.regime = (string)temp["regime"];

            orbit.semiMajorAxisKM = GetOrbitStringValue(ref data, id, num, "semi_major_axi_km");
            orbit.eccentricity = GetOrbitStringValue(ref data, id, num, "eccentricity");
            orbit.periKm = GetOrbitStringValue(ref data, id, num, "periapsis_km");
            orbit.apoKm = GetOrbitStringValue(ref data, id, num, "apoapsis_km");
            orbit.inclinDeg = GetOrbitStringValue(ref data, id, num, "inclination_deg");
            orbit.periodMin = GetOrbitStringValue(ref data, id, num, "period_min");
            orbit.epoch = GetOrbitStringValue(ref data, id, num, "epoch");
            orbit.meanMotion = GetOrbitStringValue(ref data, id, num, "mean_motion");
            orbit.raan = GetOrbitStringValue(ref data, id, num, "raan");
            orbit.argPericenter = GetOrbitStringValue(ref data, id, num, "arg_of_pericenter");
            orbit.meanAnomoly = GetOrbitStringValue(ref data, id, num, "mean_anomaly");

            return orbit;
        }

        public string GetOrbitStringValue(ref JArray data, int? id, int num, string name)
        {
            var temp = (string)data[id]["rocket"]["second_stage"]["payloads"][num]["orbit_params"][name];
            string value = "";
            if(temp == null)
            {
                value = "None";
            }
            else
            {
                value = temp;
            }
            return value;
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