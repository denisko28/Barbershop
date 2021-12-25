using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface IBarbersService
    {
        Task<IEnumerable<BarberResponse>> GetAsync();

        Task<BarberResponse> GetByIdAsync(int id);

        Task<IEnumerable<BarberResponse>> GetAsync(BarberParams parameters);

        Task<IEnumerable<AppointmentResponse>> GetAppointmentsAsync(int id);

        Task InsertAsync(BarberRequest request);

        Task UpdateAsync(BarberRequest request);

        Task DeleteAsync(int id);
    }
}
