namespace Astronomical_Learning.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FactOfTheDayContext : DbContext
    {
        public FactOfTheDayContext()
            : base("name=AzureALDB")
        {
        }

        public virtual DbSet<FactOfTheDay> FactOfTheDays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
