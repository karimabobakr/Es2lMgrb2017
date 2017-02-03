namespace Es2LMegrb_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Destinatione> Destinationes { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<OpeningHour> OpeningHours { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(e => e.Destinationes)
                .WithOptional(e => e.Album)
                .HasForeignKey(e => e.Album_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Album>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.Album)
                .HasForeignKey(e => e.Album_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Destinationes)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Area_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Sections)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Features)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoriesFeatures").MapLeftKey("Category_ID").MapRightKey("Feature_ID"));

            modelBuilder.Entity<City>()
                .HasMany(e => e.Areas)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.City_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.Country_ID);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.OpeningHours)
                .WithRequired(e => e.Day)
                .HasForeignKey(e => e.Day_ID);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Destinationes)
                .WithMany(e => e.Days)
                .Map(m => m.ToTable("Holidays").MapLeftKey("Day_ID").MapRightKey("Destination_ID"));

            modelBuilder.Entity<Destinatione>()
                .HasMany(e => e.OpeningHours)
                .WithRequired(e => e.Destinatione)
                .HasForeignKey(e => e.Destination_ID);

            modelBuilder.Entity<Destinatione>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Destinatione)
                .HasForeignKey(e => e.Destination_ID);

            modelBuilder.Entity<Destinatione>()
                .HasMany(e => e.Features)
                .WithMany(e => e.Destinationes)
                .Map(m => m.ToTable("DestinationsFeatures").MapLeftKey("Destination_ID").MapRightKey("Feature_ID"));

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Destinationes)
                .WithOptional(e => e.Section)
                .HasForeignKey(e => e.Section_ID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete();
        }
    }
}
