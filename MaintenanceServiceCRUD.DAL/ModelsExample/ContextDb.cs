using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MaintenanceServiceCRUD.DAL.Models
{
    public partial class ContextDb : DbContext
    {
        public ContextDb()
        {
        }

        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<TruckMaintenanceService> TruckMaintenanceServices { get; set; }
        public virtual DbSet<TypeTruckMaintenanceService> TypeTruckMaintenanceServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK_Employees_IdEmployee");

                entity.ToTable("Employees", "Employees");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTruckNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdTruck);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob)
                    .HasName("PK_Jobs_IdJob");

                entity.ToTable("Jobs", "Employees");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.HasKey(e => e.IdTruck)
                    .HasName("PK_Trucks_IdVehicle");

                entity.ToTable("Trucks", "Vehicles");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TruckMaintenanceService>(entity =>
            {
                entity.HasKey(e => e.IdTruckMaintenanceServices)
                    .HasName("PK_TruckMaintenanceServices_IdTruckMaintenanceServices");

                entity.ToTable("TruckMaintenanceServices", "MaintenanceServices");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.HasOne(d => d.DispatcherNavigation)
                    .WithMany(p => p.TruckMaintenanceServiceDispatcherNavigations)
                    .HasForeignKey(d => d.Dispatcher)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DriverNavigation)
                    .WithMany(p => p.TruckMaintenanceServiceDriverNavigations)
                    .HasForeignKey(d => d.Driver)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTruckNavigation)
                    .WithMany(p => p.TruckMaintenanceServices)
                    .HasForeignKey(d => d.IdTruck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckMaintenanceServices_Vehicles_IdTruck");

                entity.HasOne(d => d.IdTypeTruckMaintenanceServiceNavigation)
                    .WithMany(p => p.TruckMaintenanceServices)
                    .HasForeignKey(d => d.IdTypeTruckMaintenanceService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckMaintenanceServices_Vehicles_IdTypeTruckMaintenanceService");

                entity.HasOne(d => d.MechanicalNavigation)
                    .WithMany(p => p.TruckMaintenanceServiceMechanicalNavigations)
                    .HasForeignKey(d => d.Mechanical)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TypeTruckMaintenanceService>(entity =>
            {
                entity.HasKey(e => e.IdTypeTruckMaintenanceService)
                    .HasName("PK_TypeTruckMaintenanceServices_IdTypeTruckMaintenanceService");

                entity.ToTable("TypeTruckMaintenanceServices", "MaintenanceServices");

                entity.Property(e => e.IdTypeTruckMaintenanceService).ValueGeneratedOnAdd();

                entity.Property(e => e.TypeDescription)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
