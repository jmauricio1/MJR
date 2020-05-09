namespace Astronomical_Learning.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserLevel()
        {

        }

        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string LevelName { get; set; }

        [StringLength(64)]
        public string BadgePath { get; set; }
    }
}
