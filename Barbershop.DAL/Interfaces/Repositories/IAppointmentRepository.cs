using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> GetAsync(AppointmentParams parameters);

        Task<Barber> GetRelatedBarberAsync(int id);

        Task<Customer> GetRelatedCustomerAsync(int id);

        Task AddServicesAsync(int id, List<Service> services);

        Task<List<Service>> GetServicesAsync(int id);
    }
}
