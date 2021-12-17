using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class AccessStatusSeeder : ISeeder<AccessStatus>
    {
        private static readonly List<AccessStatus> projects = new List<AccessStatus>()
        {
            new AccessStatus
            {

            }
        };

        public void Seed(EntityTypeBuilder<AccessStatus> builder) => builder.HasData(projects);
    }
}