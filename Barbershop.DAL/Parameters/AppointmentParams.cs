using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL.Parameters
{
    public class AppointmentParams
    {
        public int? BarberId { get; set; }

        public int? CustomertId { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? StatusId { get; set; }

        public int? InvoiceId { get; set; }
    }
}
