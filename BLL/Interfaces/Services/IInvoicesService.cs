using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barbershop.BLL.Interfaces.Services
{
    public interface IInvoicesService
    {
        Task<IEnumerable<InvoiceResponse>> GetAsync();

        Task<InvoiceResponse> GetByIdAsync(int id);

        Task<IEnumerable<InvoiceResponse>> GetAsync(InvoiceParams parameters);

        Task InsertAsync(InvoiceRequest request);
    }
}
