using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<List<Service>> GetAsync(ServiceParams parameters);

        Task<List<Appointment>> GetAppointmentsAsync(int id);
    }
}
