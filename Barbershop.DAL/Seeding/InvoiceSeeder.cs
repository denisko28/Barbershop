using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using System;

namespace Barbershop.DAL.Seeding
{
    public class InvoiceSeeder : ISeeder<Invoice>
    {
        private static readonly List<Invoice> projects = new List<Invoice>()
        {
            new Invoice
            {
                Id = 1, AppointmentId = 1, CreationDateTime = new DateTime(2021, 8, 11, 14, 36, 0)
            },
            new Invoice
            {
                Id = 2, AppointmentId = 2, CreationDateTime = new DateTime(2021, 8, 18, 17, 44, 0)
            },
            new Invoice
            {
                Id = 3,AppointmentId = 5, CreationDateTime = new DateTime(2021, 8, 11, 14, 36, 0)
            }
        };

        public void Seed(EntityTypeBuilder<Invoice> builder) => builder.HasData(projects);
    }
}