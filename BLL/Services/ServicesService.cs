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
    public class ServicesService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IServiceRepository serviceRepository;

        public async Task<IEnumerable<ServiceResponse>> GetAsync()
        {
            var services = await serviceRepository.GetAsync();
            return services.Select(mapper.Map<Service, ServiceResponse>);
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var service = await serviceRepository.GetByIdAsync(id);
            return mapper.Map<Service, ServiceResponse>(service);
        }

        public async Task<IEnumerable<ServiceResponse>> GetAsync(ServiceParams parameters)
        {
            var services = await serviceRepository.GetAsync(parameters);
            return services.Select(mapper.Map<Service, ServiceResponse>);
        }

        public async Task InsertAsync(ServiceRequest request)
        {
            var service = mapper.Map<ServiceRequest, Service>(request);
            await serviceRepository.InsertAsync(service);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceRequest request)
        {
            Service oldService = await serviceRepository.GetByIdAsync(request.Id);
            Service newService = mapper.Map<ServiceRequest, Service>(request);

            await serviceRepository.UpdateAsync(newService);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await serviceRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public ServicesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            serviceRepository = this.unitOfWork.ServiceRepository;
        }
    }
}
