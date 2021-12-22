using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using System;

namespace Barbershop.DAL.Seeding
{
    public class AppointmentSeeder : ISeeder<Appointment>
    {
        private static readonly List<Appointment> projects = new List<Appointment>()
        {
            new Appointment
            {
                Id = 1,
                BarberId = 3,
                CustomerId = 1,
                AppointmentDate = new DateTime(2021, 12, 18),
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(13, 30, 0),
                CreationDate = new DateTime(2021, 12, 17),
                StatusId = 2,
            },
            new Appointment
            {
                Id = 2,
                BarberId = 3,
                CustomerId = 2,
                AppointmentDate = new DateTime(2021, 12, 18),
                StartTime = new TimeSpan(16, 45, 0),
                EndTime = new TimeSpan(17, 45, 0),
                CreationDate = new DateTime(2021, 12, 15),
                StatusId = 2
            },
            new Appointment
            {
                Id = 3,
                BarberId = 1,
                CustomerId = 4,
                AppointmentDate = new DateTime(2021, 12, 18),
                StartTime = new TimeSpan(15, 45, 0),
                EndTime = new TimeSpan(16, 30, 0),
                CreationDate = new DateTime(2021, 12, 11),
                StatusId = 3
            },
            new Appointment
            {
                Id = 4,
                BarberId = 4,
                CustomerId = 3,
                AppointmentDate = new DateTime(2021, 12, 19),
                StartTime = new TimeSpan(10, 15, 0),
                EndTime = new TimeSpan(11, 15, 0),
                CreationDate = new DateTime(2021, 12, 19),
                StatusId = 1
            },
            new Appointment
            {
                Id = 5,
                BarberId = 3,
                CustomerId = 1,
                AppointmentDate = new DateTime(2021, 12, 20),
                StartTime = new TimeSpan(14, 30, 0),
                EndTime = new TimeSpan(15, 15, 0),
                CreationDate = new DateTime(2021, 12, 17),
                StatusId = 2
            },
            new Appointment
            {
                Id = 6,
                BarberId = 4,
                CustomerId = 5,
                AppointmentDate = new DateTime(2021, 12, 20),
                StartTime = new TimeSpan(16, 30, 0),
                EndTime = new TimeSpan(18, 00, 0),
                CreationDate = new DateTime(2021, 12, 18),
                StatusId = 1
            }
        };

        public void Seed(EntityTypeBuilder<Appointment> builder) => builder.HasData(projects);
    }
}
