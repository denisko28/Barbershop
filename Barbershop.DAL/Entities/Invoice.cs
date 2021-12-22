using Barbershop.DAL.Entities.Base;
using System;

namespace Barbershop.DAL.Entities
{
    public class Invoice : Entity
    {
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public decimal Sum { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
