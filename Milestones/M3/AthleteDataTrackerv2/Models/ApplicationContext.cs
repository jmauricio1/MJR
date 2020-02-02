namespace AthleteDataTrackerv2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
       // : base("name=ApplicationContext")
        : base("name=AthleteDataTrackerDB")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AthleteEvent> AthleteEvents { get; set; }
        public virtual DbSet<AthleteResult> AthleteResults { get; set; }
        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<TeamAthlete> TeamAthletes { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

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

            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.AthleteEvents)
                .WithRequired(e => e.Athlete)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.AthleteResults)
                .WithRequired(e => e.Athlete)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.TeamAthletes)
                .WithRequired(e => e.Athlete)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.TeamAthletes)
                .WithRequired(e => e.Coach)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Coach)
                .HasForeignKey(e => e.CID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.AthleteEvents)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.EID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.AthleteResults)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.EID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.AthleteResults)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LID)
                .WillCascadeOnDelete(false);
        }
    }
}
