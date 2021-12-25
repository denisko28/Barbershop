using System;

namespace Barbershop.BLL.DTO.Requests
{
    public class InvoiceRequest
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public decimal Sum { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
