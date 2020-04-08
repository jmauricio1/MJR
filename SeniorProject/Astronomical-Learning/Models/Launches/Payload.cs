using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class Payload
    {
        public string payloadID;
        public int noradID; //List
        public string capSerial;
        public string customers; //List
        public string nationality;
        public string manufac;
        public string payloadType;
        public double plmkg;
        public double plmlb;

        public Orbit orbit = new Orbit();
    }
}