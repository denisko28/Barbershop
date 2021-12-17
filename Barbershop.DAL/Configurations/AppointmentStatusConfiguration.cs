using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class AppointmentStatusConfiguration : IEntityTypeConfiguration<AppointmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
        {
            builder.Property(status => status.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(status => status.Meaning)
                   .HasMaxLength(80);

            //new AppointmentStatusSeeder().Seed(builder);
        }
    }
}