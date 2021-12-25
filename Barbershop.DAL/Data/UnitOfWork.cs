using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using Barbershop.DAL.Interfaces.Repositories;
using Barbershop.DAL.Context;

namespace TeamworkSystem.DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BarbershopDB databaseContext;

        public IAccessStatusRepository AccessStatusRepository { get; set; }

        public IAppointmentRepository AppointmentRepository { get; }
        
        public IAppointmentStatusRepository AppointmentStatusRepository { get; }

        public IBarberRepository BarberRepository { get; }

        public ICustomerRepository CustomerRepository { get; }

        public IInvoiceRepository InvoiceRepository { get; }

        public IServiceRepository ServiceRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
            BarbershopDB databaseContext,
            IAccessStatusRepository accessStatusRepository,
            IAppointmentRepository appointmentRepository,
            IAppointmentStatusRepository appointmentStatusRepository,
            IBarberRepository barberRepository,
            ICustomerRepository customerRepository,
            IInvoiceRepository invoiceRepository,
            IServiceRepository serviceRepository)
            
        {
            this.databaseContext = databaseContext;
            AccessStatusRepository = accessStatusRepository;
            AppointmentRepository = appointmentRepository;
            AppointmentStatusRepository = appointmentStatusRepository;
            BarberRepository = barberRepository;
            CustomerRepository = customerRepository;
            InvoiceRepository = invoiceRepository;
            ServiceRepository = serviceRepository;
        }
    }
}
