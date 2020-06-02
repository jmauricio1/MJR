using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models
{
    public class DemographicViewModel
    {
        public List<CountryData> CountryDatas { get; set; }
        public List<ViewData> ViewsDatas { get; set; }
        public List<UserLevelsData> UserLevelsDatas { get; set; }
    }
}