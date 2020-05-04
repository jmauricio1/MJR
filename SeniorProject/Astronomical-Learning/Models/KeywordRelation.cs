namespace Astronomical_Learning.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KeywordRelation
    {
        public int Id { get; set; }

        public int KeywordId { get; set; }

        public int PageId { get; set; }
    }
}
