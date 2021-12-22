using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Interfaces;
using System;

namespace Barbershop.DAL.Seeding
{
    public class BarberSeeder : ISeeder<Barber>
    {
        private static readonly List<Barber> projects = new List<Barber>()
        {
            new Barber
            {
                Id = 1,
                Surname = "Олійник",
                Name = "Юрій",
                Patronymic = "Романович",
                Phone = "0509093545",
                AccessStatusId = 1,
                Password = "12345a",
                Adress = "вул. Руська, 248о",
                PassportSeries = "AB170623",
                PassportNumber = "74873869-14507",
                BirthDate = new DateTime(1998, 6, 17)
            },
            new Barber
            {
                Id = 2,
                Surname = "Магнат",
                Name = "Дмитро",
                Patronymic = "Михайлович",
                Phone = "0506551900",
                AccessStatusId = 3,
                Password = "target123",
                Adress = "вул. Головна, 119",
                PassportSeries = "427467236",
                PassportNumber = "12388549-20348",
                BirthDate = new DateTime()
            },
            new Barber
            {
                Id = 3,
                Surname = "Голойда",
                Name = "Олександр",
                Patronymic = "Сергійович",
                Phone = "0956448382",
                AccessStatusId = 1,
                Password = "baseball",
                Adress = "вул. Головна, 200",
                PassportSeries = "AB123945",
                PassportNumber = "64345650-01234",
                BirthDate = new DateTime()
            },
            new Barber
            {
                Id = 4,
                Surname = "Голуб",
                Name = "Олег",
                Patronymic = "Андрійович",
                Phone = "0675671466",
                AccessStatusId = 1,
                Password = "zag12wsx",
                Adress = "вул. Калинівська, 13-А",
                PassportSeries = "734783488",
                PassportNumber = "19910824-00026",
                BirthDate = new DateTime()
            },
        };

        public void Seed(EntityTypeBuilder<Barber> builder) => builder.HasData(projects);
    }
}