using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerResponse>> GetAsync();

        Task<CustomerResponse> GetByIdAsync(int id);

        Task<IEnumerable<CustomerResponse>> GetAsync(CustomerParams parameters);

        Task<IEnumerable<AppointmentResponse>> GetAppointmentsAsync(int id);

        Task InsertAsync(CustomerRequest request);

        Task UpdateAsync(CustomerRequest request);

        Task DeleteAsync(int id);
    }
}
