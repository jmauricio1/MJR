namespace AthleteDataTrackerv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamAthlete
    {
        public int ID { get; set; }

        public int AID { get; set; }

        public int TID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
