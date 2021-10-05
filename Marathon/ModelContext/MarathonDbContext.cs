namespace Marathon.ModelContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Windows;
    using System.Collections.Generic;

    public partial class MarathonDbContext : DbContext
    {
		public static List<Country> CountriesList { get; set; }
		public static List<Gender> GendersList { get; set; }
        public MarathonDbContext()
            : base("name=MarathonDbContext")
        {
        	GendersList = Gender.ToList();
			CountriesList = Country.ToList();
        }

        public virtual DbSet<Charity> Charity { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Marathon> Marathon { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<RaceKitOption> RaceKitOption { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<RegistrationEvent> RegistrationEvent { get; set; }
        public virtual DbSet<RegistrationStatus> RegistrationStatus { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Runner> Runner { get; set; }
        public virtual DbSet<Sponsorship> Sponsorship { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Volunteer> Volunteer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charity>()
                .HasMany(e => e.Registration)
                .WithRequired(e => e.Charity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Marathon)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Runner)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Volunteer)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventId)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.EventTypeId)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.RegistrationEvent)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventType>()
                .Property(e => e.EventTypeId)
                .IsFixedLength();

            modelBuilder.Entity<EventType>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.EventType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Runner)
                .WithRequired(e => e.Gender1)
                .HasForeignKey(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Volunteer)
                .WithRequired(e => e.Gender1)
                .HasForeignKey(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marathon>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<Marathon>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Marathon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionName)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.PayPeriod)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Staff)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceKitOption>()
                .Property(e => e.RaceKitOptionId)
                .IsFixedLength();

            modelBuilder.Entity<RaceKitOption>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<RaceKitOption>()
                .HasMany(e => e.Registration)
                .WithRequired(e => e.RaceKitOption)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.RaceKitOptionId)
                .IsFixedLength();

            modelBuilder.Entity<Registration>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Registration>()
                .Property(e => e.SponsorshipTarget)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Registration>()
                .HasMany(e => e.RegistrationEvent)
                .WithRequired(e => e.Registration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .HasMany(e => e.Sponsorship)
                .WithRequired(e => e.Registration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistrationEvent>()
                .Property(e => e.EventId)
                .IsFixedLength();

            modelBuilder.Entity<RegistrationStatus>()
                .HasMany(e => e.Registration)
                .WithRequired(e => e.RegistrationStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleId)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Runner>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<Runner>()
                .HasMany(e => e.Registration)
                .WithRequired(e => e.Runner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsorship>()
                .Property(e => e.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Staff>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Timesheet)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.RoleId)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Runner)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.CountryCode)
                .IsFixedLength();
        }
    }
}
