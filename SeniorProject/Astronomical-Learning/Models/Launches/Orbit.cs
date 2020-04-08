using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class Orbit
    {
        public string orbit;
        //Orbit Params
        public string refSys;
        public string regime;
        //longitude
        public string semiMajorAxisKM;
        public string eccentricity;
        public string periKm;
        public string apoKm;
        public string inclinDeg;
        public string periodMin;
        //lifespan
        public string epoch;
        public string meanMotion;
        public string raan;
        public string argPericenter;
        public string meanAnomoly;
        //mass returned
        //mass returned lb
        /*
        public string flightTime; //Seconds
        public string uid; //IDK if i should add this

        public string ships; //list
        public string telemetry; //Link to flightclub
        */
    }
}