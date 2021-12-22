using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL.Entities
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }
    }
}
