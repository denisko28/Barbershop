using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class CustomerSeeder : ISeeder<Customer>
    {
        private static readonly List<Customer> projects = new List<Customer>()
        {
            new Customer
            {

            }
        };

        public void Seed(EntityTypeBuilder<Customer> builder) => builder.HasData(projects);
    }
}