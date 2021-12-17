using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class AppointmentSeeder : ISeeder<Appointment>
    {
        private static readonly List<Appointment> projects = new List<Appointment>()
        {
            new Appointment
            {
                //Id = 1,
                //Barber = ,
                //Customer = ,
                //AppointmentDate = ,
                //StartTime = ,
                //EndTime = ,
                //CreationDate = ,
                //Status = ,
                //Services = ,
            }
        };

        public void Seed(EntityTypeBuilder<Appointment> builder) => builder.HasData(projects);
    }
}
