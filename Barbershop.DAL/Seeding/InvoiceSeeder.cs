using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class InvoiceSeeder : ISeeder<Invoice>
    {
        private static readonly List<Invoice> projects = new List<Invoice>()
        {
            new Invoice
            {

            }
        };

        public void Seed(EntityTypeBuilder<Invoice> builder) => builder.HasData(projects);
    }
}