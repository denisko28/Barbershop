using AutoMapper;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using Barbershop.DAL.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Barbershop.BLL.DTO.Responses;
using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.Interfaces.Services;
using System.Linq;
using Barbershop.DAL.Parameters;

namespace Barbershop.BLL.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ICustomerRepository customerRepository;

        public async Task<IEnumerable<CustomerResponse>> GetAsync()
        {
            var customers = await customerRepository.GetAsync();
            return customers.Select(mapper.Map<Customer, CustomerResponse>);
        }

        public async Task<CustomerResponse> GetByIdAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);
            return mapper.Map<Customer, CustomerResponse>(customer);
        }

        public async Task<IEnumerable<CustomerResponse>> GetAsync(CustomerParams parameters)
        {
            var customers = await customerRepository.GetAsync(parameters);
            return customers.Select(mapper.Map<Customer, CustomerResponse>);
        }

        public async Task<IEnumerable<AppointmentResponse>> GetAppointmentsAsync(int id)
        {
            var appointments = await customerRepository.GetAppointmentsAsync(id);
            return appointments.Select(mapper.Map<Appointment, AppointmentResponse>);
        }

        public async Task InsertAsync(CustomerRequest request)
        {
            var customer = mapper.Map<CustomerRequest, Customer>(request);
            await customerRepository.InsertAsync(customer);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerRequest request)
        {
            Customer oldCustomer = await customerRepository.GetByIdAsync(request.Id);
            Customer newCustomer = mapper.Map<CustomerRequest, Customer>(request);

            await customerRepository.UpdateAsync(newCustomer);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await customerRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public CustomersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            customerRepository = this.unitOfWork.CustomerRepository;
        }
    }
}
