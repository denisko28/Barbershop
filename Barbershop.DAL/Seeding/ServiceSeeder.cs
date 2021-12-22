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
                Id = 1, Name = "Стижка", Price = 250.00M, Discount = 20, Duration = 60, Enabled = true
            },
            new Service
            {
                Id = 2, Name = "Видаленя волосся воском", Price = 100.00M, Discount = 5, Duration = 15, Enabled = true
            },
            new Service
            {
                Id = 3, Name = "Стрижка з бородою", Price = 400.00M, Discount = 0, Duration = 120, Enabled = true
            },
            new Service
            {
                Id = 4, Name = "Королівське гоління", Price = 250.00M, Discount = 0, Duration = 20, Enabled = false
            },
            new Service
            {
                Id = 5, Name = "Укладка", Price = 100.00M, Discount = 10, Duration = 20, Enabled = true
            },
            new Service
            {
                Id = 6, Name = "Стрижка бороди", Price = 150.00M, Discount = 0, Duration = 20, Enabled = true
            },
            new Service
            {
                Id = 7, Name = "Дитяча стрижка", Price = 200.00M, Discount = 10, Duration = 40, Enabled = true
            },
            new Service
            {
                Id = 8, Name = "Стрижка під насадку", Price = 200.00M, Discount = 10, Duration = 45, Enabled = true
            }
        };

        public void Seed(EntityTypeBuilder<Service> builder) => builder.HasData(projects);
    }
}