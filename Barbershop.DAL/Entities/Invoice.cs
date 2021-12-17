using Barbershop.DAL.Entities.Base;
using System;

namespace Barbershop.DAL.Entities
{
    public class Invoice : Entity
    {
        public Appointment Appointment { get; set; }

        public int BarberId { get; set; }
        public Barber Barber { get; set; }

        public decimal Sum { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
