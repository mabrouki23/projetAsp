using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace projetAsp.Models
{
    public partial class storeContext : DbContext
    {
        public storeContext()
        {
        }

        public storeContext(DbContextOptions<storeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userpass> Userpasses { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=store");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Download>(entity =>
            {
                entity.ToTable("download");

                entity.HasIndex(e => e.UserId, "UserID");

                entity.Property(e => e.DownloadId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DownloadID");

                entity.Property(e => e.DownloadFilename)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Userpass>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("userpass");

                entity.Property(e => e.Username).HasMaxLength(15);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Rolename })
                    .HasName("PRIMARY");

                entity.ToTable("userrole");

                entity.Property(e => e.Username).HasMaxLength(15);

                entity.Property(e => e.Rolename).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
