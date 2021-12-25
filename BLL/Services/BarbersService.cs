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
    public class BarbersService : IBarbersService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IBarberRepository barberRepository;

        public async Task<IEnumerable<BarberResponse>> GetAsync()
        {
            var barbers = await barberRepository.GetAsync();
            return barbers.Select(mapper.Map<Barber, BarberResponse>);
        }

        public async Task<BarberResponse> GetByIdAsync(int id)
        {
            var barber = await barberRepository.GetByIdAsync(id);
            return mapper.Map<Barber, BarberResponse>(barber);
        }

        public async Task<IEnumerable<BarberResponse>> GetAsync(BarberParams parameters)
        {
            var barbers = await barberRepository.GetAsync(parameters);
            return barbers.Select(mapper.Map<Barber, BarberResponse>);
        }

        public async Task<IEnumerable<AppointmentResponse>> GetAppointmentsAsync(int id)
        {
            var appointments = await barberRepository.GetAppointmentsAsync(id);
            return appointments.Select(mapper.Map<Appointment, AppointmentResponse>);
        }

        public async Task InsertAsync(BarberRequest request)
        {
            var barbers = mapper.Map<BarberRequest, Barber>(request);
            await barberRepository.InsertAsync(barbers);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(BarberRequest request)
        {
            Barber oldBarber = await barberRepository.GetByIdAsync(request.Id);
            Barber newBarber = mapper.Map<BarberRequest, Barber>(request);

            await barberRepository.UpdateAsync(newBarber);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await barberRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public BarbersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            barberRepository = this.unitOfWork.BarberRepository;
        }
    }
}
