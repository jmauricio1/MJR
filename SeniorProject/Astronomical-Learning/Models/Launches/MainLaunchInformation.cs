using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class MainLaunchInformation 
    {
        public int flightNum;
        public string missName;
        public string missID; //List
        public string launchSuccess;

        public int launchYear;
        public string launchDateUnix;
        public string launchDateUTC;
        public string launchDateLocal;
        public string tent;
        public string tentMaxPrecise;

        public string crew;
    }
}