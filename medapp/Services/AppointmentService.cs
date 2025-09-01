using AutoMapper;
using AutoMapper.QueryableExtensions;
using medapp.Data;
using medapp.Dtos;
using medapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace medapp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync(string search, string visitType, DateTime? from, DateTime? to, int page, int pageSize)
        {
            var query = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Prescriptions)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(a => a.Patient.FullName.Contains(search) || a.Doctor.FullName.Contains(search));

            if (!string.IsNullOrEmpty(visitType))
                query = query.Where(a => a.VisitType == visitType);

            if (from.HasValue && to.HasValue)
                query = query.Where(a => a.AppointmentDate >= from && a.AppointmentDate <= to);

            return await query
                .OrderByDescending(a => a.AppointmentDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppointmentDto> GetByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Prescriptions)
                .FirstOrDefaultAsync(a => a.Id == id);

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto> CreateAsync(AppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto> UpdateAsync(int id, AppointmentDto dto)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Prescriptions)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null) return null;

            // Map master
            _mapper.Map(dto, appointment);

            // Handle prescriptions (replace old with new)
            appointment.Prescriptions.Clear();
            foreach (var p in dto.Prescriptions)
            {
                appointment.Prescriptions.Add(new PrescriptionDetail
                {
                    MedicineId = p.MedicineId,
                    Dosage = p.Dosage,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Notes = p.Notes
                });
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
