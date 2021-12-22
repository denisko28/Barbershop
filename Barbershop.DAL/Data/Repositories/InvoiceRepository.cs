using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Interfaces.Repositories;
using Barbershop.DAL.Parameters;
using Barbershop.DAL.Context;
using System;

namespace Barbershop.DAL.Data.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public override async Task<Invoice> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(barber => barber.Appointment)
                                     .SingleOrDefaultAsync(appointment => appointment.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<List<Invoice>> GetAsync(InvoiceParams parameters)
        {
            IQueryable<Invoice> source = table.Include(invoice => invoice.Appointment);

            SearchByAppointmentId(ref source, parameters.AppointmentId);
            SearchByBarberId(ref source, parameters.BarberId);
            SearchBySum(ref source, parameters.Sum);
            SearchByCreationDateTime(ref source, parameters.CreationDateTime);

            return await source.ToListAsync();
        }

        public static void SearchByAppointmentId(ref IQueryable<Invoice> source, int? id)
        {
            if (id is null || id == 0)
            {
                return;
            }

            source = source.Where(invoice => invoice.Appointment.Id == id);
        }

        public static void SearchByBarberId(ref IQueryable<Invoice> source, int? id)
        {
            if (id is null || id == 0)
            {
                return;
            }

            source = source.Where(invoice => invoice.Appointment.BarberId == id);
        }

        public static void SearchBySum(ref IQueryable<Invoice> source, decimal? sum)
        {
            if (sum is null)
            {
                return;
            }

            source = source.Where(invoice => invoice.Sum == sum);
        }

        public static void SearchByCreationDateTime(ref IQueryable<Invoice> source, DateTime? creationDateTime)
        {
            if (creationDateTime is null)
            {
                return;
            }

            source = source.Where(invoice => invoice.CreationDateTime == creationDateTime);
        }

        public InvoiceRepository(BarbershopDB databaseContext) : base(databaseContext)
        {
        }
    }
}
