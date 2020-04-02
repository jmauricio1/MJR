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
        public double semiMajorAxisKM;
        public double eccentricity;
        public double periKm;
        public double apoKm;
        public double inclinDeg;
        public double periodMin;
        //lifespan
        public string epoch;
        public double meanMotion;
        public double raan;
        public double argPericenter;
        public double meanAnomoly;
        //mass returned
        //mass returned lb
        public int flightTime; //Seconds
        public string uid; //IDK if i should add this

        public string ships; //list
        public string telemetry; //Link to flightclub
    }
}