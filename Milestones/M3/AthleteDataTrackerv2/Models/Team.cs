namespace AthleteDataTrackerv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string SchoolName { get; set; }

        public int CID { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
