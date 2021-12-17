using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(service => service.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(service => service.Name)
                .HasMaxLength(30)
                   .IsRequired();

            builder.Property(service => service.Price)
                   .IsRequired();

            builder.Property(service => service.Duration)
                   .IsRequired();

            builder.Property(service => service.Enabled)
                   .HasColumnType("bit")
                   .HasDefaultValue(true)
                   .IsRequired();

            new ServiceSeeder().Seed(builder);
        }
    }
}