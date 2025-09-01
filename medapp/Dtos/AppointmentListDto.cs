using medapp.Entities;

namespace medapp.Dtos
{
    public class AppointmentListDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public VisitType VisitType { get; set; }
        public string? Diagnosis { get; set; }
    }


    public class PrescriptionItemDto
    {
        public int? Id { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }


    public class AppointmentDetailDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public VisitType VisitType { get; set; }
        public string? Diagnosis { get; set; }
        public List<PrescriptionItemDto> Prescriptions { get; set; } = new();
    }


    public class AppointmentCreateUpdateDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public VisitType VisitType { get; set; }
        public string? Diagnosis { get; set; }
        public List<PrescriptionItemDto> Prescriptions { get; set; } = new();
    }
}
