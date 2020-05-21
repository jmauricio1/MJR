using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models
{
    public class Launch
    {
        public string missionName;
        public string missionDate;
        public string launchSuccess;
        public int flightNum;

        public string launchSite;
        public string rocketUsed;
        public string year;
        public string landSuccess;
        public List<string> shipsUsed = new List<string>();
    }
}