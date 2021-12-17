using Barbershop.DAL.Entities.Base;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class AppointmentStatus : Entity
    {
        public string Meaning { get; set; }

        public List<Appointment> Appointments = new List<Appointment>();
    }
}
