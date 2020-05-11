namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserComment")]
    public partial class UserComment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Username { get; set; }

        [Column(TypeName = "date")]
        public DateTime PostDate { get; set; }

        [Required]
        [StringLength(128)]
        public string PageFrom { get; set; }

        public bool AcceptState { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        public int ReportCount { get; set; }
    }
}
