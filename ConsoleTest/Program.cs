using System.Linq;
using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Data.Repositories;
using Barbershop.DAL.Parameters;

namespace TestConsole
{
    class Program
    {
         static async Task Main(string[] args)
        {
            const string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Barbershop.db;Integrated Security=True";
            using BarbershopDB db = new BarbershopDB(new DbContextOptionsBuilder<BarbershopDB>().UseSqlServer(connection).Options);

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            ServiceRepository ServiceRepo = new ServiceRepository(db);
            AppointmentRepository AppointmentRepo = new AppointmentRepository(db);
            BarberRepository barberRepository = new BarberRepository(db);
            CustomerRepository customerRepository = new CustomerRepository(db);

            //await repo.DeleteAsync(17);

            //Service serv = new Service { Name = "Стрижка під насадку", Price = 200, Discount = 0, Duration = 45, Enabled = false };
            //await ServiceRepo.InsertAsync(serv);
            //db.SaveChanges();

            Service service = await ServiceRepo.GetByIdAsync(2);
            Console.WriteLine(service.Price);

            List<Service> services = await ServiceRepo.GetAsync(new ServiceParams() { Enabled = false });
            Console.Write("\nНедоступні послуги: \n");
            foreach (Service service1 in services)
                Console.WriteLine(service1.Name);

            services = await ServiceRepo.GetAsync(new ServiceParams() { Discount = 10 });
            Console.Write("\nЗі знижкою 10%: \n");
            foreach (Service service1 in services)
                Console.WriteLine(service1.Name);

            services = new List<Service> { await ServiceRepo.GetCompleteEntityAsync(2), await ServiceRepo.GetCompleteEntityAsync(6) };
            await AppointmentRepo.AddServicesAsync(4, services);

            //db.SaveChanges();

            Service servi = await ServiceRepo.GetCompleteEntityAsync(4);

            List<Appointment> apps = await ServiceRepo.GetAppointmentsAsync(4);
            Console.Write("\nServices from appoint #4: \n");
            foreach (Appointment app in apps)
                Console.WriteLine(app.Barber.Id);


            //services = await repo.GetAsync(new ServiceParams() { Discount = 3 });

            //foreach (Service service1 in services)
            //    repo.UpdateAsync(service1)

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

