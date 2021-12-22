using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(project => project.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.HasOne(appointment => appointment.Barber)
                   .WithMany(barber => barber.Appointments)
                   .HasForeignKey(appointment => appointment.BarberId)
                   .OnDelete(DeleteBehavior.ClientCascade)
                   .HasConstraintName("FK_Appointments_BarberId");

            builder.HasOne(appointment => appointment.Customer)
                   .WithMany(customer => customer.Appointments)
                   .HasForeignKey(appointment => appointment.CustomerId)
                   .OnDelete(DeleteBehavior.ClientCascade)
                   .HasConstraintName("FK_Appointments_CustomerId");

            builder.HasOne(appointment => appointment.Status)
                   .WithMany(status => status.Appointments)
                   .HasForeignKey(appointment => appointment.StatusId)
                   .OnDelete(DeleteBehavior.ClientCascade)
                   .HasConstraintName("FK_Appointments_StatusId");

            builder.Property(appointment => appointment.AppointmentDate)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(appointment => appointment.StartTime)
                   .HasColumnType("time")
                   .IsRequired();

            builder.Property(appointment => appointment.EndTime)
                   .HasColumnType("time")
                   .IsRequired();

            builder.Property(appointment => appointment.CreationDate)
                   .HasColumnType("date")
                   .IsRequired();

            new AppointmentSeeder().Seed(builder);
        }
    }
}
