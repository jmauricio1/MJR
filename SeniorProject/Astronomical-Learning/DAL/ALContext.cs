namespace Astronomical_Learning.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Astronomical_Learning.Models;
    using Astronomical_Learning.Models.Search;

    public partial class ALContext : DbContext
    {
        public ALContext()
          // :base("name=ALContext")
             : base("name=AzureALDB")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AvatarPath> AvatarPaths { get; set; }
        public virtual DbSet<FactOfTheDay> FactOfTheDays { get; set; }

        public virtual DbSet<SearchKeyword> SearchKeywords { get; set; }
        public virtual DbSet<KeywordRelation> KeywordRelations { get; set; }
        public virtual DbSet<SitePage> SitePages { get; set; }

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
        }

    }
}
