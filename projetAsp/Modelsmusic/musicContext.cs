using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace projetAsp.Modelsmusic
{
    public partial class musicContext : DbContext
    {
        public musicContext()
        {
        }

        public musicContext(DbContextOptions<musicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Lineitem> Lineitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=music");
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

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.HasIndex(e => e.UserId, "UserID");

                entity.Property(e => e.InvoiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("InvoiceID");

                entity.Property(e => e.InvoiceDate).HasDefaultValueSql("'1900-01-01 00:00:00'");

                entity.Property(e => e.IsProcessed).HasColumnType("enum('y','n')");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<Lineitem>(entity =>
            {
                entity.ToTable("lineitem");

                entity.HasIndex(e => e.InvoiceId, "InvoiceID");

                entity.Property(e => e.LineItemId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LineItemID");

                entity.Property(e => e.InvoiceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("InvoiceID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(7,2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreditCardExpirationDate).HasMaxLength(50);

                entity.Property(e => e.CreditCardNumber).HasMaxLength(50);

                entity.Property(e => e.CreditCardType).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
