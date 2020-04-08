namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactOfTheDay")]
    public partial class FactOfTheDay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Text { get; set; }

        [Required]
        [StringLength(256)]
        public string Source { get; set; }
    }
}
