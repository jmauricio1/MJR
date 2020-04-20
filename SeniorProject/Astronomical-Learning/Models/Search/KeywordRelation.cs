using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Astronomical_Learning.Models.Search
{
    [Table("KeywordRelations")]
    public partial class KeywordRelation
    {
        public int Id { get; set; }

        [Required]
        public int KeywordId { get; set; }

        [Required]
        public int PageId { get; set; }
    }
}