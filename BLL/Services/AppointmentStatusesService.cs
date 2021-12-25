using AutoMapper;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using Barbershop.DAL.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Barbershop.BLL.DTO.Responses;
using System.Linq;

namespace Barbershop.BLL.Services
{
    public class AppointmentStatusesService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IAppointmentStatusRepository appointmentStatusRepository;

        public async Task<IEnumerable<AppointmentStatusResponse>> GetAsync()
        {
            var appontmentStatuses = await appointmentStatusRepository.GetAsync();
            return appontmentStatuses.Select(mapper.Map<AppointmentStatus, AppointmentStatusResponse>);
        }

        public async Task<AppointmentStatusResponse> GetByIdAsync(int id)
        {
            var appontmentStatus = await appointmentStatusRepository.GetByIdAsync(id);
            return mapper.Map<AppointmentStatus, AppointmentStatusResponse>(appontmentStatus);
        }

        public AppointmentStatusesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            appointmentStatusRepository = this.unitOfWork.AppointmentStatusRepository;
        }
    }
}
