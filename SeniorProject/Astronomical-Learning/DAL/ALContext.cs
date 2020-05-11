namespace Astronomical_Learning.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Astronomical_Learning.Models;

    public partial class ALContext : DbContext
    {
        public ALContext()
            : base("name=AzureALDB")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AvatarPath> AvatarPaths { get; set; }
        public virtual DbSet<Distance> Distances { get; set; }
        public virtual DbSet<FactOfTheDay> FactOfTheDays { get; set; }
        public virtual DbSet<KeywordRelation> KeywordRelations { get; set; }
        public virtual DbSet<LocationDistance> LocationDistances { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<SearchKeyword> SearchKeywords { get; set; }
        public virtual DbSet<SitePage> SitePages { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }

        public virtual DbSet<Quizze> Quizzes { get; set; }
        public virtual DbSet<UserQuizScore> UserQuizScores { get; set; }
        public virtual DbSet<UserLevel> UserLevels { get; set; }

        public virtual DbSet<PlanetFilter> PlanetFilters { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AvatarPath>()
                .HasMany(e => e.AspNetUsers)
                .WithRequired(e => e.AvatarPath)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Distance>()
                .HasMany(e => e.LocationDistances)
                .WithRequired(e => e.Distance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.LocationDistances)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationOneId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.LocationDistances1)
                .WithRequired(e => e.Location1)
                .HasForeignKey(e => e.LocationTwoId)
                .WillCascadeOnDelete(false);
        }
    }
}
