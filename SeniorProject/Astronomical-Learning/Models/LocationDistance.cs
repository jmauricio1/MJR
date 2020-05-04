namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationDistance")]
    public partial class LocationDistance
    {
        public int Id { get; set; }

        public int LocationOneId { get; set; }

        public int LocationTwoId { get; set; }

        public int DistanceId { get; set; }

        public virtual Distance Distance { get; set; }

        public virtual Location Location { get; set; }

        public virtual Location Location1 { get; set; }
    }
}
