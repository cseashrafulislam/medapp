using AutoMapper;
using medapp.Dtos;
using medapp.Entities;

namespace medapp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Appointment
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.Prescriptions, opt => opt.MapFrom(src => src.Prescriptions));

            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.Prescriptions, opt => opt.Ignore()); // handle separately

            // Prescription Detail
            CreateMap<PrescriptionDetail, PrescriptionDto>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name));

            CreateMap<PrescriptionDto, PrescriptionDetail>()
                .ForMember(dest => dest.Medicine, opt => opt.Ignore()); // handled by DB lookup

            // Patient
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            // Doctor
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();

            // Medicine
            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineDto, Medicine>();
        }
    }
}
