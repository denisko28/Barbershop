using Barbershop.DAL.Entities.Base;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class Service : NamedEntity
    {
        public decimal Price { get; set; }

        public int Discount { get; set; }

        public int Duration { get; set; }

        public bool Enabled { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>(); 
    }
}
