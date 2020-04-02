using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class FirstStage
    {
        public string coreSerial;
        public int flight;
        public int block;
        public bool gridfins;
        public bool legs;
        public bool reused;
        public bool landSuccess;
        public bool landIntent;
        public string landType;
        public string landVeh;
    }
}