using Barbershop.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class Appointment : Entity
    {
        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DateTime CreationDate { get; set; }

        public int StatusId { get; set; }

        public AppointmentStatus Status { get; set; }

        public Invoice Invoice { get; set; }

        public List<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
