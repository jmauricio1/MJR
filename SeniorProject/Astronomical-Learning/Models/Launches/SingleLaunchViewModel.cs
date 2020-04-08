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
            FirstStage firstStage, SecondStage secondStage, LaunchSite launchSite, LaunchLinks launchLinks,
            Fairing fairing, LaunchTimeline timeline, Ship shipList)
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

            crew = mainLaunchInfo.crew;

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
            telemetry = launchLinks.telemetry;
            details = launchLinks.details;
            upcoming = launchLinks.upcoming;
            statFireDateUTC = launchLinks.statFireDateUTC;
            statFireDateUnix = launchLinks.statFireDateUnix;

            //Fairings Information
            fairReused = fairing.fairReused;
            recAtt = fairing.recAtt;
            recovered = fairing.recovered;

            webcastLiftoff = timeline.webcastLiftoff;
            goForPropLoading = timeline.goForPropLoading;
            rp1Load = timeline.rp1Load;
            s1rp1load = timeline.s1rp1load;
            s2rp1load = timeline.s2rp1load;
            s1LoxLoad = timeline.s1LoxLoad;
            s2LoxLoad = timeline.s2LoxLoad;
            engineChill = timeline.engineChill;
            prelaunchCheck = timeline.prelaunchCheck;
            propellantPressurization = timeline.propellantPressurization;
            goForLaunch = timeline.goForLaunch;
            ignition = timeline.ignition;
            liftoff = timeline.liftoff;
            maxq = timeline.maxq;
            beco = timeline.beco; //In later launch
            meco = timeline.meco;
            stageSep = timeline.stageSep;
            secStageIgnition = timeline.secStageIgnition;

            firstStageBoostBackBurn = timeline.firstStageBoostBackBurn;
            firstStageEntryBurn = timeline.firstStageEntryBurn;
            seco1 = timeline.seco1;
            firstStageLandingBurn = timeline.firstStageLandingBurn;
            firstStageLanding = timeline.firstStageLanding;

            dragonSeparation = timeline.dragonSeparation;
            dragonSolarDep = timeline.dragonSolarDep;
            dragonBay = timeline.dragonBay;

            seco2 = timeline.seco2;
            payloadDep = timeline.payloadDep;
            fairingDep = timeline.fairingDep;
            payDep1 = timeline.payDep1;
            payDep2 = timeline.payDep2;
            secRestart = timeline.secRestart;
            seco3 = timeline.seco3;
            seco4 = timeline.seco4;

            sideSep = timeline.sideSep;
            sideBoost = timeline.sideBoost;
            centerSep = timeline.centerSep;
            centerBoost = timeline.centerBoost;
            sideEntry = timeline.sideEntry;
            centerEntry = timeline.centerEntry;
            sideLand = timeline.sideLand;
            centerLand = timeline.centerLand;

            //Ships Information
            ships = shipList.ships;
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

        public string crew { get; set; }

        //Rocket Information
        public string rocketID { get; set; }
        public string rocketName { get; set; }
        public string rocketType { get; set; }

        //First Stage Information
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
        public int? block2 { get; set; }
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
        public string telemetry{ get; set; }

        public string ytID { get; set; }
        public string details { get; set; }
        public string upcoming { get; set; }
        public string statFireDateUTC { get; set; }
        public string statFireDateUnix { get; set; }

        //Launch Site Information
        public string siteID { get; set; }
        public string locLong { get; set; }

        //Fairings Information
        public string fairReused { get; set; }
        public string recAtt { get; set; }
        public string recovered { get; set; }

        //Timeline Information
        public int? webcastLiftoff { get; set; }
        public int? goForPropLoading { get; set; }
        public int? rp1Load { get; set; }
        public int? s1rp1load { get; set; }
        public int? s2rp1load { get; set; }
        public int? s1LoxLoad { get; set; }
        public int? s2LoxLoad { get; set; }
        public int? engineChill { get; set; }
        public int? prelaunchCheck { get; set; }
        public int? propellantPressurization { get; set; }
        public int? goForLaunch { get; set; }
        public int? ignition { get; set; }
        public int? liftoff { get; set; }
        public int? maxq { get; set; }
        public int? beco { get; set; } //In later launches
        public int? meco { get; set; }
        public int? stageSep { get; set; }
        public int? secStageIgnition { get; set; }
        //Thing
        public int? firstStageBoostBackBurn { get; set; }
        public int? firstStageEntryBurn { get; set; }
        public int? seco1 { get; set; }
        public int? firstStageLandingBurn { get; set; }
        public int? firstStageLanding { get; set; }

        //Dragon
        public int? dragonSeparation { get; set; }
        public int? dragonSolarDep { get; set; }
        public int? dragonBay { get; set; }

        //Other
        public int? seco2 { get; set; }
        public int? payloadDep { get; set; }
        public int? fairingDep { get; set; }
        public int? payDep1 { get; set; }
        public int? payDep2 { get; set; }
        public int? secRestart { get; set; }
        public int? seco3 { get; set; }
        public int? seco4 { get; set; }

        //Cores
        public int? sideSep { get; set; }
        public int? sideBoost { get; set; }
        public int? centerSep { get; set; }
        public int? centerBoost { get; set; }
        public int? sideEntry { get; set; }
        public int? centerEntry { get; set; }
        public int? sideLand { get; set; }
        public int? centerLand { get; set; }

        //Ships Information
        public List<string> ships { get; set; }
    }
}