using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models.Launches
{
    public class LaunchTimeline
    {
        //TIMELINE
        public int webcastLiftoff;
        public int goForPropLoading;
        public int rp1Load;
        public int s1LoxLoad;
        public int s2LoxLoad;
        public int engineChill;
        public int prelaunchCheck;
        public int propellantPressurization;
        public int goForLaunch;
        public int ignition;
        public int liftoff;
        public int maxq;
        public int meco;
        public int stageSep;
        public int secStageIgnition;
        //public int firstStageBoostBackBurn;
        public int firstStageEntryBurn;
        public int seco1;
        public int firstStageLandingBurn;
        public int firstStageLanding;
        public int dragonSeparation;
    }
}