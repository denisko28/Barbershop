using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class ServiceSeeder : ISeeder<Service>
    {
        private static readonly List<Service> projects = new List<Service>()
        {
            new Service
            {
                Id = 1, Name = "Кроп", Price = 250, Discount = 0, Duration = 2, Appointments = new List<Appointment>()
            }
        };

        public void Seed(EntityTypeBuilder<Service> builder) => builder.HasData(projects);
    }
}