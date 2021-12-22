using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class AppointmentServiceConfiguration : IEntityTypeConfiguration<AppointmentService>
    {
        public void Configure(EntityTypeBuilder<AppointmentService> builder)
        {
            builder.HasKey(appServ => new { appServ.AppointmentId, appServ.ServiceId });

            builder.HasOne(appServ => appServ.Appointment)
                   .WithMany(appointment => appointment.AppointmentServices)
                   .HasForeignKey(appServ => appServ.AppointmentId)
                   .HasConstraintName("FK_AppointmentService_AppointmentId");

            builder.HasOne(appServ => appServ.Service)
                   .WithMany(appointment => appointment.AppointmentServices)
                   .HasForeignKey(appServ => appServ.ServiceId)
                   .HasConstraintName("FK_AppointmentService_ServiceId");

            new AppointmentServiceSeeder().Seed(builder);
        }
    }
}
