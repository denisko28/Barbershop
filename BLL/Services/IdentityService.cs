using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.Validation.Requests;
using Barbershop.BLL.Interfaces.Services;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Exceptions;
using Barbershop.DAL.Interfaces;
using Barbershop.DAL.Interfaces.Repositories;

namespace Barbershop.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IBarberRepository barberRepository;

        private readonly ICustomerRepository customerRepository;

        public async Task<bool> SignInAsync(UserSignInRequest request)
        {
            IPerson? User = null;
            if (request.UserRole == "Customer")
                User = await customerRepository.GetByIdAsync(request.Id);
            else if (request.UserRole == "Barber")
                User = await barberRepository.GetByIdAsync(request.Id);

            if (User is null)
                throw new EntityNotFoundException(
                    $"{request.UserRole} with user id {request.Id} not found.");

            bool correctPass = false;

            if (User is Barber)
                correctPass = barberRepository.CheckPassword(request.Id, request.Password);
            else if (User is Customer)
                correctPass = customerRepository.CheckPassword(request.Id, request.Password);

            if (!correctPass)
            {
                throw new EntityNotFoundException("Incorrect username or password.");
            }

            return true;
        }

        public async Task<int> SignUpAsync(CustomerSignUpRequest request)
        {
            var validator = new CustomerSignUpRequestValidator();
            var signUpResult = validator.Validate(request);

            if (!signUpResult.IsValid)
            {
                string errors = string.Join("\n",
                    signUpResult.Errors.Select(error => error.ErrorMessage));
                throw new ArgumentException(errors);
            }

            var customer = mapper.Map<CustomerSignUpRequest, Customer>(request);

            int recordId = await customerRepository.InsertAndGetIdAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return recordId;
        }

        public IdentityService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBarberRepository barberRepository,
            ICustomerRepository customerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.barberRepository = barberRepository;
            this.customerRepository = customerRepository;
        }
    }
}
