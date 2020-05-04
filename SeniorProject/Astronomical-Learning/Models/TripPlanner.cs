namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripPlanner")]
    public partial class TripPlanner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string PlanetOne { get; set; }

        [Required]
        [StringLength(128)]
        public string PlanetTwo { get; set; }

        public long Distance { get; set; }
    }
}
