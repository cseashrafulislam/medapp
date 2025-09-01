using medapp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace medapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<PrescriptionDetail> PrescriptionDetails => Set<PrescriptionDetail>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(p => p.FullName).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.FullName).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Medicine>().Property(m => m.Name).HasMaxLength(150).IsRequired();


            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PrescriptionDetail>()
            .HasOne(p => p.Appointment)
            .WithMany(a => a.Prescriptions)
            .HasForeignKey(p => p.AppointmentId);


            modelBuilder.Entity<PrescriptionDetail>()
            .HasOne(p => p.Medicine)
            .WithMany(m => m.Prescriptions)
            .HasForeignKey(p => p.MedicineId);
        }
    }
}
