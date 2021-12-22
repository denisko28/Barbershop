using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;

namespace Barbershop.DAL.Seeding
{
    public class AppointmentServiceSeeder : ISeeder<AppointmentService>
    {
        private static readonly List<AppointmentService> projects = new List<AppointmentService>()
        {
            new AppointmentService
            {
                AppointmentId = 1, ServiceId = 3
            },

            new AppointmentService
            {
                AppointmentId = 2, ServiceId = 1
            },

            new AppointmentService
            {
                AppointmentId = 3, ServiceId = 8
            },

            new AppointmentService
            {
                AppointmentId = 4, ServiceId = 2
            },

            new AppointmentService
            {
                AppointmentId = 4, ServiceId = 6
            },

            new AppointmentService
            {
                AppointmentId = 5, ServiceId = 5
            },

            new AppointmentService
            {
                AppointmentId = 5, ServiceId = 6
            },

            new AppointmentService
            {
                AppointmentId = 6, ServiceId = 3
            }
        };

        public void Seed(EntityTypeBuilder<AppointmentService> builder) => builder.HasData(projects);
    }
}
