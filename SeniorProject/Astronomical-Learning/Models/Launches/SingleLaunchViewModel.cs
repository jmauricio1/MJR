using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Astronomical_Learning.Models.Launches;

namespace Astronomical_Learning.Models.Launches
{
    public class SingleLaunchViewModel
    {
        public SingleLaunchViewModel(MainLaunchInformation mainLaunchInfo, RocketInformation rocketInfo,
            FirstStage firstStage, SecondStage secondStage)
        {
            //Main Launch Information
            flightNum = mainLaunchInfo.flightNum;
            missName = mainLaunchInfo.missName;
            missID = mainLaunchInfo.missID;
            launchSuccess = mainLaunchInfo.launchSuccess;

            launchYear = mainLaunchInfo.launchYear;
            launchDateUnix = mainLaunchInfo.launchDateUnix;
            launchDateUTC = mainLaunchInfo.launchDateUTC;
            launchDateLocal = mainLaunchInfo.launchDateLocal;
            tent = mainLaunchInfo.tent;
            tentMaxPrecise = mainLaunchInfo.tentMaxPrecise;

            //Rocket Information
            rocketID = rocketInfo.rocketID;
            rocketName = rocketInfo.rocketName;
            rocketType = rocketInfo.rocketType;

            //First Stage Information
            coreSerial = firstStage.coreSerial;
            flight = firstStage.flight;
            block = firstStage.block;
            gridfins = firstStage.gridfins;
            legs = firstStage.legs;
            reused = firstStage.reused;
            landSuccess = firstStage.landSuccess;
            landIntent = firstStage.landIntent;
            landType = firstStage.landType;
            landVeh = firstStage.landVeh;

            //Second Stage Information
            block2 = secondStage.block2;
            payloads = secondStage.payloads;
        }

        //Main Launch Information
        public int flightNum { get; set; }
        public string missName { get; set; }
        public string missID { get; set; } //List
        public string launchSuccess { get; set; }

        public int launchYear { get; set; }
        public string launchDateUnix { get; set; }
        public string launchDateUTC { get; set; }
        public string launchDateLocal { get; set; }
        public string tent { get; set; }
        public string tentMaxPrecise { get; set; }

        //Rocket Information
        public string rocketID { get; set; }
        public string rocketName { get; set; }
        public string rocketType { get; set; }

        //First Satge Information
        public string coreSerial { get; set; }
        public int flight { get; set; }
        public int block { get; set; }
        public string gridfins { get; set; }
        public string legs { get; set; }
        public string reused { get; set; }
        public string landSuccess { get; set; }
        public string landIntent { get; set; }
        public string landType { get; set; }
        public string landVeh { get; set; }

        //Second Stage Information
        public int block2 { get; set; }
        public List<Payload> payloads { get; set; }

    }
}