using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class BarberSeeder : ISeeder<Barber>
    {
        private static readonly List<Barber> projects = new List<Barber>()
        {
            new Barber
            {

            }
        };

        public void Seed(EntityTypeBuilder<Barber> builder) => builder.HasData(projects);
    }
}