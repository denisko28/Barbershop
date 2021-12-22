using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(invoice => invoice.Id)
                   .IsRequired();

            builder.HasOne(invoice => invoice.Appointment)
                   .WithOne(appointment => appointment.Invoice)
                   .HasForeignKey<Invoice>(invoice => invoice.AppointmentId)
                   .OnDelete(DeleteBehavior.ClientCascade)
                   .HasConstraintName("FK_Invoice_AppointmentId");

            builder.Property(invoice => invoice.Sum)
                   .HasColumnType("decimal")
                   .HasPrecision(6, 2)
                   .IsRequired();

            new InvoiceSeeder().Seed(builder);
        }
    }
}