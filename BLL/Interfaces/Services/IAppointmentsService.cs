using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface IAppointmentsService
    {
        Task<IEnumerable<AppointmentResponse>> GetAsync();

        Task<AppointmentResponse> GetByIdAsync(int id);

        Task InsertAsync(AppointmentRequest request);

        Task UpdateAsync(AppointmentRequest request);

        //Task DeleteAsync(int id);
    }
}
