namespace Astronomical_Learning.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserQuizScore
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public int QuizID { get; set; }

        public int HighestScore { get; set; }
    }
}
