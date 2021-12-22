using Barbershop.DAL.Entities;
using Barbershop.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.DAL.Context
{
    public class BarbershopDB : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Barber> Barbers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<AppointmentService> AppointmentServices { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<AppointmentStatus> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AccessStatusConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BarberConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentServiceConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }

        public BarbershopDB(DbContextOptions<BarbershopDB> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
