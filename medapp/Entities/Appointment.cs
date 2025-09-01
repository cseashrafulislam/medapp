namespace medapp.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public DateTime AppointmentDate { get; set; }
        public string VisitType { get; set; }
        public string? Diagnosis { get; set; }
        public ICollection<PrescriptionDetail> Prescriptions { get; set; } = new List<PrescriptionDetail>();
    }
}
