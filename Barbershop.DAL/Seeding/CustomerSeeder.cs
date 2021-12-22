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
                Id = 1, Surname = "Антонюк", Name = "Микола", Patronymic = "Петрович", Phone = "0503743740", AccessStatusId = 1, Password = "123456"
            },
            new Customer
            {
                Id = 2, Surname = "Романик", Name = "Андрій", Patronymic = "Васильович", Phone = "0932719030", AccessStatusId = 1, Password = "qwerty"
            },
            new Customer
            {
                Id = 3, Surname = "Цапенко", Name = "Микита", Patronymic = "Ярославович", Phone = "0955561483", AccessStatusId = 2, Password = "1q2w3e"
            },
            new Customer
            {
                Id = 4, Surname = "Кулько", Name = "Іван", Patronymic = "Валентинович", Phone = "0509568141", AccessStatusId = 1, Password = "abc123"
            },
            new Customer
            {
                Id = 5, Surname = "Шарапенко", Name = "Данило", Patronymic = "Федорович", Phone = "0966006012", AccessStatusId = 1, Password = "666666"
            },
            new Customer
            {
                Id = 6, Surname = "Симоненко", Name = "Ярослав", Patronymic = "Гриорович", Phone = "0683047208", AccessStatusId = 1, Password = "zxcvbnm"
            },
            new Customer
            {
                Id = 8, Surname = "Назаренко", Name = "Данило", Patronymic = "Миколайович", Phone = "0509708588", AccessStatusId = 3, Password = "qazwsx"
            },
            new Customer
            {
                Id = 7, Surname = "Таралевич", Name = "Олександр", Patronymic = "Олегович", Phone = "0952767141", AccessStatusId = 1, Password = "computer"
            },
        };

        public void Seed(EntityTypeBuilder<Customer> builder) => builder.HasData(projects);
    }
}