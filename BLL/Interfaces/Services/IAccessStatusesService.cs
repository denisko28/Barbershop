using Barbershop.BLL.DTO.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface IAccessStatusesService
    {
        Task<IEnumerable<AccessStatusResponse>> GetAsync();

        Task<AccessStatusResponse> GetByIdAsync(int id);
    }
}
