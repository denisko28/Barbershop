using Barbershop.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class AccessStatus : Entity
    {
        public string Meaning { get; set; }

        public List<Customer> Customers = new List<Customer>();
        public List<Barber> Barbers = new List<Barber>();
    }
}
