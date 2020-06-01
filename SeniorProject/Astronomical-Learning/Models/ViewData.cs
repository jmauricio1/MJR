namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewData")]
    public partial class ViewData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string PageName { get; set; }

        public int ViewCount { get; set; }
    }
}
