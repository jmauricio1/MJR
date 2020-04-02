using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Astronomical_Learning.Models.Launches;

namespace Astronomical_Learning.Models.Launches
{
    public class SingleLaunchViewModel
    {
        public SingleLaunchViewModel(MainLaunchInformation mainLaunchInfo)
        {
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
        }

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
    }
}