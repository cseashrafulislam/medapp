using medapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace medapp.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            await db.Database.MigrateAsync();


            if (!db.Patients.Any())
            {
                db.Patients.AddRange(new[]
                {
                    new Patient { FullName = "John Doe", Email = "john@example.com" },
                    new Patient { FullName = "Jane Smith", Email = "jane@example.com" }
                    });
            }


            if (!db.Doctors.Any())
            {
                db.Doctors.AddRange(new[]
                {
                    new Doctor { FullName = "Dr. Smith", Specialization = "Physician" },
                    new Doctor { FullName = "Dr. Adams", Specialization = "Cardiologist" }
                    });
            }


            if (!db.Medicines.Any())
            {
                db.Medicines.AddRange(new[]
                {
                    new Medicine { Name = "Amoxicillin" },
                    new Medicine { Name = "Paracetamol" },
                    new Medicine { Name = "Ibuprofen" }
                    });
            }


            if (!db.Appointments.Any())
            {
                var appt = new Appointment
                {
                    PatientId = db.Patients.First().Id,
                    DoctorId = db.Doctors.First().Id,
                    AppointmentDate = DateTime.Today,
                    Diagnosis = "Flu"
                };
                db.Appointments.Add(appt);
            }


            await db.SaveChangesAsync();
        }
    }
}
