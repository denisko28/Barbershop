using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Interfaces.Repositories;
using Barbershop.DAL.Parameters;
using Barbershop.DAL.Context;

namespace Barbershop.DAL.Data.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public override async Task<Service> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(service => service.AppointmentServices)
                                     .ThenInclude(appServ => appServ.Appointment)
                                     .FirstAsync(service => service.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<List<Service>> GetAsync(ServiceParams parameters)
        {
            IQueryable<Service> source = table;

            SearchByName(ref source, parameters.Name);
            SearchByPrice(ref source, parameters.Price);
            SearchByDiscount(ref source, parameters.Discount);
            SearchByDuration(ref source, parameters.Duration);
            SearchByEnabled(ref source, parameters.Enabled);

            return await source.ToListAsync();
        }

        public static void SearchByName(ref IQueryable<Service> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            source = source.Where(service => service.Name == name);
        }

        public static void SearchByPrice(ref IQueryable<Service> source, decimal? price)
        {
            if (price is null)
            {
                return;
            }

            source = source.Where(service => service.Price == price);
        }

        public static void SearchByDiscount(ref IQueryable<Service> source, int? discount)
        {
            if (discount is null)
            {
                return;
            }

            source = source.Where(service => service.Discount == discount);
        }

        public static void SearchByDuration(ref IQueryable<Service> source, int? duration)
        {
            if (duration is null)
            {
                return;
            }

            source = source.Where(service => service.Duration == duration);
        }

        public static void SearchByEnabled(ref IQueryable<Service> source, bool? enabled)
        {
            if (enabled is null)
            {
                return;
            }

            source = source.Where(service => service.Enabled == enabled);
        }

        public async Task<List<Appointment>> GetAppointmentsAsync(int id)
        {
            var service = (await GetCompleteEntityAsync(id));

            if (service is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return service?.AppointmentServices
                          .Select(appServ => appServ.Appointment).ToList();
        }

        public ServiceRepository(BarbershopDB databaseContext) : base(databaseContext)
        {
        }
    }
}
