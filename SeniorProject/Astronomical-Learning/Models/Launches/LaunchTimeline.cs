using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class LaunchTimeline
    {
        //TIMELINE
        //Things in common between all launches
        public int? webcastLiftoff;
        public int? goForPropLoading;
        public int? rp1Load;
        public int? s1rp1load;
        public int? s2rp1load;
        public int? s1LoxLoad;
        public int? s2LoxLoad;
        public int? engineChill;
        public int? prelaunchCheck;
        public int? propellantPressurization;
        public int? goForLaunch;
        public int? ignition;
        public int? liftoff;
        public int? maxq;
        public int? beco; //In later launches
        public int? meco;
        public int? stageSep;
        public int? secStageIgnition;
        //Things
        public int? firstStageBoostBackBurn;
        public int? firstStageEntryBurn;
        public int? seco1;
        public int? firstStageLandingBurn;
        public int? firstStageLanding;

        //Dragon
        public int? dragonSeparation;
        public int? dragonSolarDep;
        public int? dragonBay;

        //Other
        public int? seco2;
        public int? payloadDep;
        public int? fairingDep;
        public int? payDep1;
        public int? payDep2;
        public int? secRestart;
        public int? seco3;
        public int? seco4;

        //Cores
        public int? sideSep;
        public int? sideBoost;
        public int? centerSep;
        public int? centerBoost;
        public int? sideEntry;
        public int? centerEntry;
        public int? sideLand;
        public int? centerLand;
    }
}