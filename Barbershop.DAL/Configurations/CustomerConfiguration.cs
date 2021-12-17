using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(customer => customer.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(customer => customer.Name)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(customer => customer.Surname)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(customer => customer.Patronymic)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(customer => customer.Phone)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.HasOne(customer => customer.AccessStatus)
                   .WithMany(status => status.Customers)
                   .HasForeignKey(customer => customer.AccessStatusId)
                   .HasConstraintName("FK_Customer_AccessStatusId");

            builder.Property(customer => customer.Password)
                   .HasMaxLength(20)
                   .IsRequired();

            //new CustomerSeeder().Seed(builder);
        }
    }
}