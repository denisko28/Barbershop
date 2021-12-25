using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.BLL.DTO.Responses
{
    public class InvoiceResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public AppointmentResponse? Appointment { get; set; }

        public decimal Sum { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
