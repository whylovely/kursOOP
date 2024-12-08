using Microsoft.EntityFrameworkCore;
using kursOOP.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace kursOOP.Data
{
    public class DatabaseContext : DbContext
    {
        // Конструктор
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Server=postgres;Database=property;Trusted_Connection=True;MultipleActiveResultSets=true")));

        }

        // Наборы данных
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Настройка модели
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка Property
            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Address).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Area).IsRequired();
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.Status).IsRequired();
                entity.Property(p => p.TypeId).IsRequired();
                entity.HasOne(p => p.Owner)
                      .WithMany(o => o.Properties)
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Настройка Owner
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Name).IsRequired().HasMaxLength(100);
                entity.Property(o => o.ContactInfo).HasMaxLength(255);
            });

            // Настройка Tenant
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.ContactInfo).HasMaxLength(255);
            });

            // Настройка RentalAgreement
            modelBuilder.Entity<RentalAgreement>(entity =>
            {
                entity.HasKey(ra => ra.Id);
                entity.Property(ra => ra.StartDate).IsRequired();
                entity.Property(ra => ra.MonthlyRent).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(ra => ra.Status).IsRequired();
                entity.HasOne(ra => ra.Property)
                      .WithMany()
                      .HasForeignKey(ra => ra.PropertyId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ra => ra.Tenant)
                      .WithMany(t => t.RentalAgreements)
                      .HasForeignKey(ra => ra.TenantId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Настройка Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.PaymentDate).IsRequired();
                entity.Property(p => p.PaymentMethod).IsRequired();
                entity.HasOne(p => p.Agreement)
                      .WithMany(ra => ra.Payments)
                      .HasForeignKey(p => p.AgreementId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}