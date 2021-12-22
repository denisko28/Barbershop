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
    public class BarberRepository : GenericRepository<Barber>, IBarberRepository
    {
        public override async Task<Barber> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(barber => barber.Appointments)
                                     .Include(barber => barber.AccessStatus)
                                     .SingleOrDefaultAsync(appointment => appointment.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<List<Barber>> GetAsync(BarberParams parameters)
        {
            IQueryable<Barber> source = table.Include(barber => barber.AccessStatus);

            SearchBySurname(ref source, parameters.Surname);
            SearchByName(ref source, parameters.Name);
            SearchByPatronimic(ref source, parameters.Patronymic);
            SearchByPhone(ref source, parameters.Phone);
            SearchByAccessStatusId(ref source, parameters.AccessStatusId);
            SearchByAdress(ref source, parameters.Adress);

            return await source.ToListAsync();
        }

        public static void SearchByName(ref IQueryable<Barber> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            source = source.Where(barber => barber.Name == name);
        }

        public static void SearchBySurname(ref IQueryable<Barber> source, string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return;
            }

            source = source.Where(barber => barber.Surname == surname);
        }

        public static void SearchByPatronimic(ref IQueryable<Barber> source, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(patronymic))
            {
                return;
            }

            source = source.Where(barber => barber.Patronymic == patronymic);
        }

        public static void SearchByPhone(ref IQueryable<Barber> source, string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return;
            }

            source = source.Where(barber => barber.Phone == phone);
        }

        public static void SearchByAccessStatusId(ref IQueryable<Barber> source, int? accessStatus)
        {
            if (accessStatus is null)
            {
                return;
            }

            source = source.Where(barber => barber.AccessStatusId == accessStatus);
        }

        public static void SearchByAdress(ref IQueryable<Barber> source, string adress)
        {
            if (string.IsNullOrWhiteSpace(adress))
            {
                return;
            }

            source = source.Where(barber => barber.Adress == adress);
        }

        public async Task<List<Appointment>> GetAppointmentsAsync(int id)
        {
            var barber = await table.Include(barber => barber.Appointments)
                                    .ThenInclude(appointment => appointment.Customer)
                                    .SingleOrDefaultAsync(barber => barber.Id == id);

            if (barber is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return barber?.Appointments;
        }

        public BarberRepository(BarbershopDB databaseContext) : base(databaseContext)
        {
        }
    }
}
