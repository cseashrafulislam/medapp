namespace medapp.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string VisitType { get; set; } // "First" or "Follow-up"

        public string Notes { get; set; }

        public List<PrescriptionDto> Prescriptions { get; set; } = new();
    }
    public class PrescriptionDto
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Notes { get; set; }
    }
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

