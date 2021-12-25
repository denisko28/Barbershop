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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public override async Task<Customer> GetCompleteEntityAsync(int id)
        {
            var project = await table.Include(customer => customer.Appointments)
                                     .Include(customer => customer.AccessStatus)
                                     .SingleOrDefaultAsync(customer => customer.Id == id);

            return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<int> InsertAndGetIdAsync(Customer customer)
        {
            await InsertAsync(customer);
            return customer.Id;
        }

        public async Task<List<Customer>> GetAsync(CustomerParams parameters)
        {
            IQueryable<Customer> source = table.Include(customer => customer.AccessStatus);

            SearchBySurname(ref source, parameters.Surname);
            SearchByName(ref source, parameters.Name);
            SearchByPatronimic(ref source, parameters.Patronymic);
            SearchByPhone(ref source, parameters.Phone);
            SearchByAccessStatusId(ref source, parameters.AccessStatusId);

            return await source.ToListAsync();
        }

        public static void SearchByName(ref IQueryable<Customer> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            source = source.Where(customer => customer.Name == name);
        }

        public static void SearchBySurname(ref IQueryable<Customer> source, string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return;
            }

            source = source.Where(customer => customer.Surname == surname);
        }

        public static void SearchByPatronimic(ref IQueryable<Customer> source, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(patronymic))
            {
                return;
            }

            source = source.Where(customer => customer.Patronymic == patronymic);
        }

        public static void SearchByPhone(ref IQueryable<Customer> source, string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return;
            }

            source = source.Where(customer => customer.Phone == phone);
        }

        public static void SearchByAccessStatusId(ref IQueryable<Customer> source, int? accessStatus)
        {
            if (accessStatus is null)
            {
                return;
            }

            source = source.Where(customer => customer.AccessStatusId == accessStatus);
        }

        public bool CheckPassword(int? customerId, string password)
        {
            IQueryable<Customer> source = table.Where(customer => customer.Id == customerId && customer.Password == password);

            if (customerId is null || string.IsNullOrWhiteSpace(password) || source.Count() == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Appointment>> GetAppointmentsAsync(int id)
        {
            var customer = await table.Include(customer => customer.Appointments)
                                      .ThenInclude(appointment => appointment.Barber)
                                      .SingleOrDefaultAsync(customer => customer.Id == id);

            if (customer is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return customer?.Appointments;
        }

        public CustomerRepository(BarbershopDB databaseContext) : base(databaseContext)
        {
        }
    }
}
