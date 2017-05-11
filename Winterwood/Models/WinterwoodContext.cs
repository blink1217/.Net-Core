using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Winterwood.Models
{
    public partial class WinterwoodContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=orchardstreaming.database.windows.net,1433;Database=Winterwood;User ID=orchardkt;Password=Framework4.5;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("IX_AccountId");

                entity.Property(e => e.TaxPointDate).HasColumnType("datetime");

                entity.Property(e => e.TotalGross).HasColumnType("decimal");

                entity.Property(e => e.TotalNet).HasColumnType("decimal");

                entity.Property(e => e.TotalVat).HasColumnType("decimal");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_dbo.Invoice_dbo.Account_AccountId");
            });
        }
    }
}