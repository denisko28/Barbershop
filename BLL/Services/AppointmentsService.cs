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

namespace Barbershop.BLL.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IAppointmentRepository appointmentRepository;

        public async Task<IEnumerable<AppointmentResponse>> GetAsync()
        {
            var appointments = await appointmentRepository.GetAsync();
            return appointments.Select(mapper.Map<Appointment, AppointmentResponse>);
        }

        public async Task<AppointmentResponse> GetByIdAsync(int id)
        {
            var appointment = await appointmentRepository.GetByIdAsync(id);
            return mapper.Map<Appointment, AppointmentResponse>(appointment);
        }

        public async Task InsertAsync(AppointmentRequest request)
        {
            var appointment = mapper.Map<AppointmentRequest, Appointment>(request);
            await appointmentRepository.InsertAsync(appointment);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppointmentRequest request)
        {
            Appointment oldAppointment = await appointmentRepository.GetByIdAsync(request.Id);
            Appointment newAppointment = mapper.Map<AppointmentRequest, Appointment>(request);
            await appointmentRepository.UpdateAsync(newAppointment);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await appointmentRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public AppointmentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            appointmentRepository = this.unitOfWork.AppointmentRepository;
        }
    }
}
