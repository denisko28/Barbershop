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
    public class AccessStatusesService : IAccessStatusesService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IAccessStatusRepository accessStatusRepository;

        public async Task<IEnumerable<AccessStatusResponse>> GetAsync()
        { 
            var accessStatuses = await accessStatusRepository.GetAsync();
            return accessStatuses.Select(mapper.Map<AccessStatus, AccessStatusResponse>);
        }

        public async Task<AccessStatusResponse> GetByIdAsync(int id)
        {
            var accessStatus = await accessStatusRepository.GetByIdAsync(id);
            return mapper.Map<AccessStatus, AccessStatusResponse>(accessStatus);
        }

        //public async Task InsertAsync(AccessStatusRequest request)
        //{
        //    var ticket = mapper.Map<AccessStatusRequest, AccessStatus>(request);
        //    await accessStatusRepository.InsertAsync(ticket);
        //    await unitOfWork.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(AccessStatusRequest entity)
        //{
        //    var ticket = await ticketsRepository.GetByIdAsync(request.Id);
        //    ticket.ProjectId = request.ProjectId;
        //    ticket.ExecutorId = request.ExecutorId;
        //    ticket.Title = request.Title;
        //    ticket.Type = request.Type;
        //    ticket.Description = request.Description;
        //    ticket.Status = request.Status;
        //    ticket.Priority = request.Priority;
        //    ticket.Deadline = request.Deadline;
        //    await ticketsRepository.UpdateAsync(ticket);
        //    await unitOfWork.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var entity = await GetByIdAsync(id);
        //    await Task.Run(() => table.Remove(entity));
        //}

        public AccessStatusesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            accessStatusRepository = this.unitOfWork.AccessStatusRepository;
        }
    }
}
