using medapp.Dtos;

namespace medapp.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync(string search, string visitType, DateTime? from, DateTime? to, int page, int pageSize);
        Task<AppointmentDto> GetByIdAsync(int id);
        Task<AppointmentDto> CreateAsync(AppointmentDto dto);
        Task<AppointmentDto> UpdateAsync(int id, AppointmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
