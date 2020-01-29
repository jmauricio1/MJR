namespace AthleteDataTrackerv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AthleteEvent
    {
        public int ID { get; set; }

        public int AID { get; set; }

        public int EID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Event Event { get; set; }
    }
}
