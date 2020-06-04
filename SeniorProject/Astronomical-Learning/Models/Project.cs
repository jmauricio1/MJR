using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Astronomical_Learning.Models
{
    [Table("Projects")]
    public partial class Project
    {

        public int Id { get; set; }

        
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime PostDate { get; set; }

        public bool AcceptState { get; set; }

    }
}