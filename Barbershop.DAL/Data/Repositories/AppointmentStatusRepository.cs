using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Interfaces.Repositories;
using Barbershop.DAL.Context;


namespace Barbershop.DAL.Data.Repositories
{
    public class AppointmentStatusRepository : GenericRepository<AppointmentStatus>, IAppointmentStatusRepository
    {
        public override async Task<AppointmentStatus> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(appstatus => appstatus.Appointments)
                                     .SingleOrDefaultAsync(appointment => appointment.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<List<AppointmentStatus>> GetAsync(string meaning)
        {
            IQueryable<AppointmentStatus> source = table;

            if (!string.IsNullOrWhiteSpace(meaning))
            {
                source.Where(appstatus => appstatus.Meaning == meaning);
            }

            return await source.ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsAsync(int id)
        {
            var appstatus = await table.Include(appstatus => appstatus.Appointments)
                                  .SingleOrDefaultAsync(appstatus => appstatus.Id == id);

            if (appstatus is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return appstatus?.Appointments;
        }

        public AppointmentStatusRepository(BarbershopDB databaseContext) : base(databaseContext)
        {
        }
    }
}
