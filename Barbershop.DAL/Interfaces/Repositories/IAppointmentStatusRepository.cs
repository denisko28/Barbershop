using Barbershop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Barbershop.DAL.Interfaces.Repositories
{
    public interface IAppointmentStatusRepository : IRepository<AppointmentStatus>
    {
        Task<List<AppointmentStatus>> GetAsync(string meaning);

        Task<List<Appointment>> GetAppointmentsAsync(int id);
    }
}
