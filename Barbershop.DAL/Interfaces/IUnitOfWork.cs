using System.Threading.Tasks;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces.Repositories;

namespace Barbershop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAppointmentRepository AppointmentRepository { get; }

        IAppointmentStatusRepository AppointmentStatusRepository { get; }

        IBarberRepository BarberRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IInvoiceRepository InvoiceRepository { get; }

        IServiceRepository ServiceRepository { get; }

        Task SaveChangesAsync();
    }
}
