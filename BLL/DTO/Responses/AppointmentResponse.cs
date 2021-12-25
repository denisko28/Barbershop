using System;

namespace Barbershop.BLL.DTO.Responses
{
    public class AppointmentResponse
    {
        public int Id { get; set; }

        public int BarberId { get; set; }
        public BarberResponse? Barber { get; set; }

        public int CustomerId { get; set; }
        public CustomerResponse? Customer { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime CreationDate { get; set; }

        public int StatusId { get; set; }

        public AppointmentStatusResponse? Status { get; set; }

        public InvoiceResponse? Invoice { get; set; }
    }
}
