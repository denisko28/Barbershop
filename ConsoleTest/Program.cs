using System.Linq;
using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barbershop.db;Integrated Security=True";
            using BarbershopDB db = new BarbershopDB(new DbContextOptionsBuilder<BarbershopDB>().UseSqlServer(connection).Options);

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //Service serv = new Service {Id = 1, Name = "Кроп", Price = 250, Discount = 0, Duration = 2, Appointments = new List<Appointment>() };
            //db.Services.Add(serv);
            //db.SaveChanges();

            var ser = db.Services.ToArray();
            Console.WriteLine(ser[0]);

            //var query = db.Deals
            //   .Include(d => d.Book)
            //   //.AsEnumerable()
            //   .GroupBy(d => d.Book.Id, d => d.Book)
            //   .Select(d => new { BookId = d.Key, Count = d.Count() })
            //   .Join(db.Books, d => d.BookId, b => b.Id, (d, Book) => new { Book, d.Count })
            //   .OrderByDescending(d => d.Count);

            //var sql = query.ToQueryString();

            //var result = query.ToArray();
        }
    }


}

