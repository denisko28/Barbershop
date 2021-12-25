using AutoMapper;
using Barbershop.BLL.DTO.Requests;
using Barbershop.BLL.DTO.Responses;
using Barbershop.DAL.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateCustomerSignUpMaps()
        {
            CreateMap<CustomerSignUpRequest, Customer>();
        }

        private void CreateAccessStatusesMaps()
        {
            CreateMap<AccessStatusRequest, AccessStatus>();
            CreateMap<AccessStatus, AccessStatusResponse>();
        }

        private void CreateAppointmentsMaps()
        {
            CreateMap<AppointmentRequest, Appointment>();
            CreateMap<Appointment, AppointmentResponse>();
        }

        private void CreateAppointmentStatusesMaps()
        {
            CreateMap<AppointmentStatusRequest, AppointmentStatus>();
            CreateMap<AppointmentStatus, AppointmentStatusResponse>();
        }

        private void CreateBarbersMaps()
        {
            CreateMap<BarberRequest, Barber>();
            CreateMap<Barber, BarberResponse>();
        }

        private void CreateCustomersMaps()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();
        }

        private void CreateInvoicesMaps()
        {
            CreateMap<InvoiceRequest, Invoice>();
            CreateMap<Invoice, InvoiceResponse>();
        }

        private void CreateServicesMaps()
        {
            CreateMap<ServiceRequest, Service>();
            CreateMap<Service, ServiceResponse>();
        }

        public AutoMapperProfile()
        {
            CreateCustomerSignUpMaps();
            CreateAccessStatusesMaps();
            CreateAppointmentsMaps();
            CreateAppointmentStatusesMaps();
            CreateBarbersMaps();
            CreateCustomersMaps();
            CreateInvoicesMaps();
            CreateServicesMaps();
        }
    }
}
