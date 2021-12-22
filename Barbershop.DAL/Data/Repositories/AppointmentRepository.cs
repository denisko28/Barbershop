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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override async Task<Appointment> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(appointment => appointment.Barber)
                                     .Include(appointment => appointment.Customer)
                                     .Include(appointment => appointment.AppointmentServices)
                                     .ThenInclude(appServ => appServ.Service)
                                     .FirstAsync(appointment => appointment.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<List<Appointment>> GetAsync(AppointmentParams parameters)
        {
            IQueryable<Appointment> source = table.Include(appointment => appointment.Barber)
                                                  .Include(appointment => appointment.Customer);

            SearchByBarberId(ref source, parameters.BarberId);
            SearchByCustomerId(ref source, parameters.CustomertId);
            SearchByAppointmentDate(ref source, parameters.AppointmentDate);
            SearchByStartTime(ref source, parameters.StartTime);
            SearchByCreationDate(ref source, parameters.CreationDate);
            SearchByStatusId(ref source, parameters.StatusId);
            SearchByInvoiceId(ref source, parameters.InvoiceId);

            return await source.ToListAsync();
        }

        public async Task<Barber> GetRelatedBarberAsync(int id)
        {
            var appointment = await table.Include(appointment => appointment.Barber)
                                     .SingleOrDefaultAsync(appointment => appointment.Id == id);
                    

            return appointment?.Barber ?? throw new EntityNotFoundException(
                GetEntityNotFoundErrorMessage(id));
        }

        public async Task<Customer> GetRelatedCustomerAsync(int id)
        {
            var appointment = await table.Include(appointment => appointment.Customer)
                                     .SingleOrDefaultAsync(appointment => appointment.Id == id);


            return appointment?.Customer ?? throw new EntityNotFoundException(
                GetEntityNotFoundErrorMessage(id));
        }

        public static void SearchByBarberId(ref IQueryable<Appointment> source, int? barberId)
        {
            if (barberId is null || barberId == 0)
            {
                return;
            }

            source = source.Where(appointment => appointment.BarberId == barberId);
        }

        public static void SearchByCustomerId(ref IQueryable<Appointment> source, int? customerId)
        {
            if (customerId is null || customerId == 0)
            {
                return;
            }

            source = source.Where(appointment => appointment.CustomerId == customerId);
        }

        public static void SearchByAppointmentDate(ref IQueryable<Appointment> source, DateTime? appointmentDate)
        {
            if (appointmentDate is null)
            {
                return;
            }

            source = source.Where(appointment => appointment.AppointmentDate == appointmentDate);
        }

        public static void SearchByStartTime(ref IQueryable<Appointment> source, TimeSpan? startTime)
        {
            if (startTime is null)
            {
                return;
            }

            source = source.Where(appointment => appointment.StartTime == startTime);
        }

        public static void SearchByCreationDate(ref IQueryable<Appointment> source, DateTime? creationDate)
        {
            if (creationDate is null)
            {
                return;
            }

            source = source.Where(appointment => appointment.CreationDate == creationDate);
        }

        public static void SearchByStatusId(ref IQueryable<Appointment> source, int? statusId)
        {
            if (statusId is null || statusId == 0)
            {
                return;
            }

            source = source.Where(appointment => appointment.StatusId == statusId);
        }

        public static void SearchByInvoiceId(ref IQueryable<Appointment> source, int? invoiceId)
        {
            if (invoiceId is null || invoiceId == 0)
            {
                return;
            }

            source = source.Where(appointment => appointment.Invoice.Id == invoiceId);
        }

        public async Task AddServicesAsync(int id, List<Service> services)
        {
            var appointment = await GetCompleteEntityAsync(id);

            if (appointment is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            appointment?.AppointmentServices.AddRange(services.Select(service => new AppointmentService { AppointmentId = id, Service = service }));
        }

        public async Task<List<Service>> GetServicesAsync(int id)
        {
            var appointment = await GetCompleteEntityAsync(id);

            if (appointment is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return appointment?.AppointmentServices
                              .Select(appServ => appServ.Service).ToList();
        }

        public AppointmentRepository(BarbershopDB databaseContext)
            : base(databaseContext)
        {
        }
    }
}
