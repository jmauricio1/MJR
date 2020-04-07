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
            FirstStage firstStage, SecondStage secondStage, LaunchSite launchSite, LaunchLinks launchLinks)
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

            //Launch Site Information
            siteID = launchSite.siteID;
            locLong = launchSite.locLong;

            //Launch Links Information
            patch = launchLinks.patch;
            patchSmall = launchLinks.patchSmall;
            redditCampaign = launchLinks.redditCampaign;
            redditLaunch = launchLinks.redditLaunch;
            redditRecovery = launchLinks.redditRecovery;
            redditMedia = launchLinks.redditMedia;
            presskit = launchLinks.presskit;
            articleLink = launchLinks.articleLink;
            wikipedia = launchLinks.wikipedia;
            videoLink = launchLinks.videoLink;
            ytID = launchLinks.ytID;
            details = launchLinks.details;
            upcoming = launchLinks.upcoming;
            statFireDateUTC = launchLinks.statFireDateUTC;
            statFireDateUnix = launchLinks.statFireDateUnix;
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

        //Launch Links Information
        //Links
        public string patch { get; set; }
        public string patchSmall { get; set; }
        public string redditCampaign { get; set; }
        public string redditLaunch { get; set; }
        public string redditRecovery { get; set; }
        public string redditMedia { get; set; }
        public string presskit { get; set; }
        public string articleLink { get; set; }
        public string wikipedia { get; set; }
        public string videoLink { get; set; }
        public string ytID { get; set; }
        public string details { get; set; }
        public string upcoming { get; set; }
        public string statFireDateUTC { get; set; }
        public string statFireDateUnix { get; set; }

        //Launch Site Information
        public string siteID { get; set; }
        public string locLong { get; set; }
    }
}