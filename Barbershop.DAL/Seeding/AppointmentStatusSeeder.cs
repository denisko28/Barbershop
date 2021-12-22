using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class AppointmentStatusSeeder : ISeeder<AppointmentStatus>
    {
        private static readonly List<AppointmentStatus> projects = new List<AppointmentStatus>()
        {
            new AppointmentStatus
            {
                Id = 1, Meaning = "Очікується"
            },
            new AppointmentStatus
            {
                Id = 2, Meaning = "Виконано"
            },
            new AppointmentStatus
            {
                Id = 3, Meaning = "Відхилено"
            },
        };

        public void Seed(EntityTypeBuilder<AppointmentStatus> builder) => builder.HasData(projects);
    }
}