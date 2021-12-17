using Barbershop.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace Barbershop.DAL.Entities
{
    public class Barber : Person
    {
        public string Adress { get; set; }

        public string PassportSeries { get; set; }

        public string PassportNumber  { get; set; }

        public DateTime BirthDate { get; set; }


        public List<Appointment> Appointments = new List<Appointment>();
    }
}
