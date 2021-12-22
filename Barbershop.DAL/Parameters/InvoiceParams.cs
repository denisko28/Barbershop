using Barbershop.DAL.Entities;
using System;

namespace Barbershop.DAL.Parameters
{
    public class InvoiceParams
    {
        public int? AppointmentId { get; set; }

        public int? BarberId { get; set; }

        public decimal? Sum { get; set; }

        public DateTime? CreationDateTime { get; set; }
    }
}
