namespace Astronomical_Learning.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quizze")]
    public partial class Quizze
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
