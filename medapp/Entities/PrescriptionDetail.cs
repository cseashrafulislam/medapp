namespace medapp.Entities
{
    public class PrescriptionDetail
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
        public string Dosage { get; set; } = string.Empty; // e.g. 500mg 2x/day
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
