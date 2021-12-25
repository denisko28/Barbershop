using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<int> InsertAndGetIdAsync(Customer customer);

        Task<List<Customer>> GetAsync(CustomerParams parameters);

        Task<List<Appointment>> GetAppointmentsAsync(int id);

        bool CheckPassword(int? customerId, string password);
    }
}
