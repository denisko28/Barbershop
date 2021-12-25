using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Parameters;
using System.Collections.Generic;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        Task<List<Barber>> GetAsync(BarberParams parameters);

        Task<List<Appointment>> GetAppointmentsAsync(int id);

        bool CheckPassword(int? barberId, string password);
    }
}
