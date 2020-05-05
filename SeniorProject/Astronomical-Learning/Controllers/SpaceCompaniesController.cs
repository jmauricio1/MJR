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

            if (id == null)
            {
                id = 1;
            }
            id--;

            MainLaunchInformation mainInfo;
            RocketInformation rocketInformation;
            FirstStage firstStage;
            SecondStage secondStage;
            LaunchSite launchSite;
            LaunchLinks launchLinks;
            Fairing fairings;
            LaunchTimeline timeline;
            Ship ships;

            try
            {
                mainInfo = GetMainLaunchInfo(ref data, id);
                rocketInformation = GetRocketInformation(ref data, id);
                firstStage = GetFirstStageInformation(ref data, id);
                secondStage = GetSecondStageInformation(ref data, id);
                launchSite = GetLaunchSiteInformation(ref data, id);
                launchLinks = GetLinksInformation(ref data, id);
                fairings = GetFairingsInformation(ref data, id);
                timeline = GetTimelineInformation(ref data, id);
                ships = GetShipsInformation(ref data, id);
            }
             catch
            {
                return RedirectToAction("CustomError", "Home", new { errorName = "Cannot find details for this launch.", errorMessage = "Please try again later when we have more information about this launch." });
            }



            

            SingleLaunchViewModel viewModel = new SingleLaunchViewModel(mainInfo, rocketInformation,
                firstStage, secondStage, launchSite, launchLinks, fairings, timeline, ships);
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
                mainInfo.missID = "-";
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

            if ((string)data[id]["crew"] == null)
            {
                mainInfo.crew = "-";
            }
            else
            {
                mainInfo.crew = (string)data[id]["crew"];
            }

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

            var temp = data[id]["rocket"]["first_stage"]["cores"][0];

            firstStage.coreSerial = GetFirstStageString(ref data, id, "core_serial");
            firstStage.flight = (int)data[id]["rocket"]["first_stage"]["cores"][0]["flight"];

            if ((string)temp["block"] == null)
            {
                firstStage.block = 0;
            }
            else
            {
                firstStage.block = (int)temp["block"];
            }

            firstStage.gridfins = GetFirstStageString(ref data, id, "gridfins");
            firstStage.legs = GetFirstStageString(ref data, id, "legs");
            firstStage.reused = GetFirstStageString(ref data, id, "reused");

            if ((string)temp["land_success"] == null)
            {
                firstStage.landSuccess = "-";
            }
            else
            {
                firstStage.landSuccess = (string)temp["land_success"];
            }

            firstStage.landIntent = GetFirstStageString(ref data, id, "landing_intent");
            firstStage.landType = GetFirstStageString(ref data, id, "landing_type");
            firstStage.landVeh = GetFirstStageString(ref data, id, "landing_vehicle");

            return firstStage;
        }

        public string GetFirstStageString(ref JArray data, int? id, string name)
        {
            var temp = (string)data[id]["rocket"]["first_stage"]["cores"][0][name];
            string value = "";
            if (temp == null)
            {
                value = "-";
            }
            else
            {
                value = temp;
            }
            return value;
        }

        public SecondStage GetSecondStageInformation(ref JArray data, int? id)
        {
            SecondStage secondStage = new SecondStage();

            var temp = data[id]["rocket"]["second_stage"];

            secondStage.block2 = (int?)temp["block"];
            List<Payload> payloads = new List<Payload>();
            for (int i = 0; i < data[id]["rocket"]["second_stage"]["payloads"].Count(); i++)
            {
                Payload current = new Payload();

                current.payloadID = (string)temp["payloads"][i]["payload_id"];
                //current.noradID = (int)temp["payloads"][i]["norad_id"][0];
                current.capSerial = (string)temp["payloads"][i]["cap_serial"];
                current.customers = (string)temp["payloads"][i]["customers"][0];
                current.nationality = (string)temp["payloads"][i]["nationality"];
                current.manufac = (string)temp["payloads"][i]["manufacturer"];
                current.payloadType = (string)temp["payloads"][i]["payload_type"];

                if ((string)temp["payloads"][i]["payload_mass_kg"] == null)
                {
                    current.plmkg = 0.0;
                }
                else
                {
                    current.plmkg = (double)temp["payloads"][i]["payload_mass_kg"];
                    current.plmlb = (double)temp["payloads"][i]["payload_mass_lbs"];
                }

                payloads.Add(current);
            }

            for (int j = 0; j < (int)temp["payloads"].Count(); j++)
            {
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
            if (temp == null)
            {
                value = "-";
            }
            else
            {
                value = temp;
            }
            return value;
        }

        public LaunchSite GetLaunchSiteInformation(ref JArray data, int? id)
        {
            LaunchSite current = new LaunchSite();

            current.siteID = (string)data[id]["launch_site"]["site_id"];
            current.locLong = (string)data[id]["launch_site"]["site_name_long"];

            return current;
        }

        public LaunchLinks GetLinksInformation(ref JArray data, int? id)
        {
            LaunchLinks current = new LaunchLinks();

            current.patch = GetLinkString(ref data, id, "mission_patch");
            current.patchSmall = GetLinkString(ref data, id, "mission_patch_small");
            current.redditCampaign = GetLinkString(ref data, id, "reddit_campaign");
            current.redditLaunch = GetLinkString(ref data, id, "reddit_launch");
            current.redditRecovery = GetLinkString(ref data, id, "reddit_recovery");
            current.redditMedia = GetLinkString(ref data, id, "reddit_media");
            current.presskit = GetLinkString(ref data, id, "presskit");
            current.articleLink = GetLinkString(ref data, id, "article_link");
            current.wikipedia = GetLinkString(ref data, id, "wikipedia");
            current.videoLink = GetLinkString(ref data, id, "video_link");
            current.ytID = GetLinkString(ref data, id, "youtube_id");
            if((string)data[id]["telemetry"]["flight_club"] != null)
            {
                current.telemetry = (string)data[id]["telemetry"]["flight_club"];
            }
            else
            {
                current.telemetry = "#";
            }

            var temp = data[id];

            current.details = (string)temp["details"];
            current.upcoming = (string)temp["upcoming"];
            current.statFireDateUTC = (string)temp["static_fire_date_utc"];
            current.statFireDateUnix = (string)temp["static_fire_date_unix"];

            return current;
        }

        public string GetLinkString(ref JArray data, int? id, string name)
        {
            var temp = (string)data[id]["links"][name];
            string value;
            if (temp == null)
            {
                value = "#";
            }
            else
            {
                value = temp;
            }
            return value;
        }

        public Fairing GetFairingsInformation(ref JArray data, int? id)
        {
            Fairing current = new Fairing();
            var temp = data[id]["rocket"]["fairings"];

            if(temp.HasValues == false)
            {
                
            }
            else
            {
                current.fairReused = (string)temp["reused"];
                current.recAtt = (string)temp["recovery_attempt"];
                current.recovered = (string)temp["recovered"];
            }

            return current;
        }

        public LaunchTimeline GetTimelineInformation(ref JArray data, int? id)
        {
            LaunchTimeline current = new LaunchTimeline();
            if(data[id]["timeline"].HasValues == false)
            {

            }
            else
            {
                current.webcastLiftoff = TimelineHelper(ref data, id, "webcast_liftoff");
                current.goForPropLoading = TimelineHelper(ref data, id, "go_for_prop_loading");
                current.rp1Load = TimelineHelper(ref data, id, "rp1_loading");
                current.s1rp1load = TimelineHelper(ref data, id, "stage1_rp1_loading");
                current.s2rp1load = TimelineHelper(ref data, id, "stage2_rp1_loading");
                current.s1LoxLoad = TimelineHelper(ref data, id, "stage1_lox_loading");
                current.s2LoxLoad = TimelineHelper(ref data, id, "stage2_lox_loading");
                current.engineChill = TimelineHelper(ref data, id, "engine_chill");
                current.prelaunchCheck = TimelineHelper(ref data, id, "prelaunch_checks");
                current.propellantPressurization = TimelineHelper(ref data, id, "propellant_pressurization");
                current.goForLaunch = TimelineHelper(ref data, id, "go_for_launch");
                current.ignition = TimelineHelper(ref data, id, "ignition");
                current.liftoff = TimelineHelper(ref data, id, "liftoff");
                current.maxq = TimelineHelper(ref data, id, "maxq");
                current.beco = TimelineHelper(ref data, id, "beco");//In later launch
                current.meco = TimelineHelper(ref data, id, "meco");
                current.stageSep = TimelineHelper(ref data, id, "stage_sep");
                current.secStageIgnition = TimelineHelper(ref data, id, "second_stage_ignition");

                current.firstStageBoostBackBurn = TimelineHelper(ref data, id, "first_stage_boostback_burn");
                current.firstStageEntryBurn = TimelineHelper(ref data, id, "first_stage_entry_burn");
                current.seco1 = TimelineHelper(ref data, id, "seco-1");
                current.firstStageLandingBurn = TimelineHelper(ref data, id, "first_stage_landing_burn");
                current.firstStageLanding = TimelineHelper(ref data, id, "first_stage_landing");

                current.dragonSeparation = TimelineHelper(ref data, id, "dragon_separation");
                current.dragonSolarDep = TimelineHelper(ref data, id, "dragon_solar_deploy");
                current.dragonBay = TimelineHelper(ref data, id, "dragon_bay_door_deploy");

                current.seco2 = TimelineHelper(ref data, id, "seco-2");
                current.payloadDep = TimelineHelper(ref data, id, "payload_deploy");
                current.fairingDep = TimelineHelper(ref data, id, "fairing_deploy");
                current.payDep1 = TimelineHelper(ref data, id, "payload_deploy_1");
                current.payDep2 = TimelineHelper(ref data, id, "payload_deploy_2");
                current.secRestart = TimelineHelper(ref data, id, "second_stage_restart");
                current.seco3 = TimelineHelper(ref data, id, "seco-3");
                current.seco4 = TimelineHelper(ref data, id, "seco-4");

                current.sideSep = TimelineHelper(ref data, id, "side_core_sep");
                current.sideBoost = TimelineHelper(ref data, id, "side_core_boostback");
                current.centerSep = TimelineHelper(ref data, id, "center_stage_sep");
                current.centerBoost = TimelineHelper(ref data, id, "center_core_boostback");
                current.sideEntry = TimelineHelper(ref data, id, "side_core_entry_burn");
                current.centerEntry = TimelineHelper(ref data, id, "center_core_entry_burn");
                current.sideLand = TimelineHelper(ref data, id, "side_core_landing");
                current.centerLand = TimelineHelper(ref data, id, "center_core_landing");
            }

            return current;
        }

        public int? TimelineHelper(ref JArray data, int? id, string name)
        {
            int? value;

            value = (int?)data[id]["timeline"][name];

            return value;
        }


        public Ship GetShipsInformation(ref JArray data, int? id)
        {
            Ship list = new Ship();

            string temp = "";
            for(int i = 0; i < data[id]["ships"].Count(); i++)
            {
                temp = (string)data[id]["ships"][i];
                list.ships.Add(temp);
            }

            return list;
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