using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<List<Invoice>> GetAsync(InvoiceParams parameters);
    }
}
