using Barbershop.DAL.Entities.Base;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class Customer : Person
    {
        public List<Appointment> Appointments = new List<Appointment>();
    }
}
