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
    public class InvoicesService : IInvoicesService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IInvoiceRepository invoiceRepository;

        public async Task<IEnumerable<InvoiceResponse>> GetAsync()
        {
            var customers = await invoiceRepository.GetAsync();
            return customers.Select(mapper.Map<Invoice, InvoiceResponse>);
        }

        public async Task<InvoiceResponse> GetByIdAsync(int id)
        {
            var customer = await invoiceRepository.GetByIdAsync(id);
            return mapper.Map<Invoice, InvoiceResponse>(customer);
        }

        public async Task<IEnumerable<InvoiceResponse>> GetAsync(InvoiceParams parameters)
        {
            var customers = await invoiceRepository.GetAsync(parameters);
            return customers.Select(mapper.Map<Invoice, InvoiceResponse>);
        }

        public async Task InsertAsync(InvoiceRequest request)
        {
            var customers = mapper.Map<InvoiceRequest, Invoice>(request);
            await invoiceRepository.InsertAsync(customers);
            await unitOfWork.SaveChangesAsync();
        }

        public InvoicesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            invoiceRepository = this.unitOfWork.InvoiceRepository;
        }
    }
}
