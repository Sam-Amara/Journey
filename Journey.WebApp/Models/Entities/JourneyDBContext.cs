using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Journey.WebApp.Models.Entities
{
    public partial class JourneyDBContext : DbContext
    {
        public JourneyDBContext()
        {
        }

        public JourneyDBContext(DbContextOptions<JourneyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlbumPhoto> AlbumPhoto { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Traveler> Traveler { get; set; }
        public virtual DbSet<TravelerAlbum> TravelerAlbum { get; set; }
        public virtual DbSet<TravelerPhoto> TravelerPhoto { get; set; }
        public virtual DbSet<TravelerRelationships> TravelerRelationships { get; set; }
        public virtual DbSet<TravelersCities> TravelersCities { get; set; }
        public virtual DbSet<TravelersTrips> TravelersTrips { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<TripActivities> TripActivities { get; set; }
        public virtual DbSet<TripCities> TripCities { get; set; }
        public virtual DbSet<TripDetails> TripDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("No DB connection string provided");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumPhoto>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.PhotoId });

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumPhoto)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumPhot__Album__5FB337D6");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.AlbumPhoto)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumPhot__Photo__60A75C0F");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CityState).HasMaxLength(40);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Traveler>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Traveler__A9D10534141F2709")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AboutMe).HasMaxLength(2000);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email2).HasMaxLength(40);

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hobbies).HasMaxLength(1000);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.Occupation).HasMaxLength(100);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.SocialMedia).HasMaxLength(1000);
            });

            modelBuilder.Entity<TravelerAlbum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Descript).HasMaxLength(2000);

                entity.Property(e => e.TravelerId).HasColumnName("TravelerID");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.TravelerAlbum)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelerA__Trave__59FA5E80");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TravelerAlbum)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__TravelerA__TripI__59063A47");
            });

            modelBuilder.Entity<TravelerPhoto>(entity =>
            {
                entity.HasIndex(e => e.FilePath)
                    .HasName("UQ__Traveler__48D910BDD8D6C39B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Loc).HasMaxLength(100);

                entity.Property(e => e.PhotoName).HasMaxLength(200);
            });

            modelBuilder.Entity<TravelerRelationships>(entity =>
            {
                entity.HasKey(e => new { e.TravelerId1, e.TravelerId2 });

                entity.Property(e => e.TravelerId1).HasColumnName("TravelerID1");

                entity.Property(e => e.TravelerId2).HasColumnName("TravelerID2");

                entity.Property(e => e.IsEmergencyContact)
                    .HasColumnName("isEmergencyContact")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFollower)
                    .HasColumnName("isFollower")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Relationship)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.TravelerId1Navigation)
                    .WithMany(p => p.TravelerRelationshipsTravelerId1Navigation)
                    .HasForeignKey(d => d.TravelerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelerR__Trave__3C69FB99");

                entity.HasOne(d => d.TravelerId2Navigation)
                    .WithMany(p => p.TravelerRelationshipsTravelerId2Navigation)
                    .HasForeignKey(d => d.TravelerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelerR__Trave__3D5E1FD2");
            });

            modelBuilder.Entity<TravelersCities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.HasLived)
                    .HasColumnName("hasLived")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasVisited)
                    .HasColumnName("hasVisited")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCurrent)
                    .HasColumnName("isCurrent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TravelerAddress).HasMaxLength(200);

                entity.Property(e => e.TravelerId).HasColumnName("TravelerID");

                entity.Property(e => e.WantVisit)
                    .HasColumnName("wantVisit")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TravelersCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__CityI__4BAC3F29");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.TravelersCities)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__Trave__4CA06362");
            });

            modelBuilder.Entity<TravelersTrips>(entity =>
            {
                entity.HasKey(e => new { e.TripId, e.TravelerId });

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.TravelerId).HasColumnName("TravelerID");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.TravelersTrips)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__Trave__4316F928");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TravelersTrips)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__TripI__4222D4EF");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Descript).HasMaxLength(2000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TripName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TripActivities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityType).HasMaxLength(20);

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.Note).HasMaxLength(2000);

                entity.Property(e => e.TripDetailsId).HasColumnName("TripDetailsID");

                entity.HasOne(d => d.TripDetails)
                    .WithMany(p => p.TripActivities)
                    .HasForeignKey(d => d.TripDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripActiv__TripD__5629CD9C");
            });

            modelBuilder.Entity<TripCities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2000);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TripCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripCitie__CityI__4F7CD00D");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripCities)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripCitie__TripI__5070F446");
            });

            modelBuilder.Entity<TripDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accomodation)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AccomodationDetails).HasMaxLength(1000);

                entity.Property(e => e.InboundTransportation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.InboundTransportationDetails).HasMaxLength(1000);

                entity.Property(e => e.OutboundTransportation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OutboundTransportationDetails).HasMaxLength(1000);

                entity.Property(e => e.TripCitiesId).HasColumnName("TripCitiesID");

                entity.HasOne(d => d.TripCities)
                    .WithMany(p => p.TripDetails)
                    .HasForeignKey(d => d.TripCitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripDetai__TripC__534D60F1");
            });
        }
    }
}
