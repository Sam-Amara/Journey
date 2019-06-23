using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Journey.WebApp.Data
{
    public partial class JourneyDBContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
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
                throw new Exception("DB connection failed");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                    .HasConstraintName("FK__AlbumPhot__Album__14270015");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.AlbumPhoto)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumPhot__Photo__151B244E");
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

            //modelBuilder.Entity<ApplicationUser>()
            //     .HasOne(t => t.Traveler)
            //     .WithOne(u => u.User)
            //     .HasConstraintName("FK_Traveler_AspNetUsers_UserID")
            //     .IsRequired();

            modelBuilder.Entity<Traveler>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AboutMe).HasMaxLength(2000);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email2).HasMaxLength(40);

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hobbies).HasMaxLength(1000);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.Occupation).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.SocialMedia).HasMaxLength(1000);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(450);
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
                    .HasConstraintName("FK__TravelerA__Trave__10566F31");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TravelerAlbum)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK__TravelerA__TripI__0F624AF8");
            });

            modelBuilder.Entity<TravelerPhoto>(entity =>
            {
                entity.HasIndex(e => e.FilePath)
                    .HasName("UQ__Traveler__48D910BDC44C4D2D")
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
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFollower)
                    .HasColumnName("isFollower")
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Relationship)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.TravelerId1Navigation)
                    .WithMany(p => p.TravelerRelationshipsTravelerId1Navigation)
                    .HasForeignKey(d => d.TravelerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelerR__Trave__7B5B524B");

                entity.HasOne(d => d.TravelerId2Navigation)
                    .WithMany(p => p.TravelerRelationshipsTravelerId2Navigation)
                    .HasForeignKey(d => d.TravelerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelerR__Trave__7C4F7684");
            });

            modelBuilder.Entity<TravelersCities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.HasLived)
                    .HasColumnName("hasLived")
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasVisited)
                    .HasColumnName("hasVisited")
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCurrent)
                    .HasColumnName("isCurrent")
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TravelerAddress).HasMaxLength(200);

                entity.Property(e => e.TravelerId).HasColumnName("TravelerID");

                entity.Property(e => e.WantVisit)
                    .HasColumnName("wantVisit")
                    .IsRequired()
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TravelersCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__CityI__08B54D69");

                entity.HasOne(d => d.Traveler)
                    .WithMany(p => p.TravelersCities)
                    .HasForeignKey(d => d.TravelerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__Trave__09A971A2");
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
                    .HasConstraintName("FK__Travelers__Trave__01142BA1");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TravelersTrips)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Travelers__TripI__00200768");
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
                    .HasConstraintName("FK__TripActiv__TripD__6A30C649");
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
                    .HasConstraintName("FK__TripCitie__CityI__6383C8BA");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripCities)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripCitie__TripI__6477ECF3");
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
                    .HasConstraintName("FK__TripDetai__TripC__6754599E");
            });
        }
    }
}
