using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteDataTrackerv2.Models
{
    public class AthleteDataViewModel
    {
        public AthleteDataViewModel(Athlete athlete, AthleteResult[] results)
            {
            FName = athlete.FName;
            LName = athlete.LName;
            Gender = athlete.Gender;
            Results = results;
            }

        [Required]
        [StringLength(50)]
        public string FName { get; set; }

        [Required]
        [StringLength(50)]
        public string LName { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        public AthleteResult[] Results { get; set; }
    }
}