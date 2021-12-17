using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop.DAL
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<BarbershopDB>
    {
        public BarbershopDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BarbershopDB>();

            // получаем строку подключения из файла appsettings.json
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barbershop.db;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            return new BarbershopDB(optionsBuilder.Options);
        }
    }
}
