using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Barbershop.DAL.Entities;
using Barbershop.DAL.Seeding;

namespace Barbershop.DAL.Configurations
{
    public class BarberConfiguration : IEntityTypeConfiguration<Barber>
    {
        public void Configure(EntityTypeBuilder<Barber> builder)
        {
            builder.Property(barber => barber.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(barber => barber.Name)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(barber => barber.Surname)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(barber => barber.Patronymic)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(barber => barber.Phone)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.HasOne(barber => barber.AccessStatus)
                   .WithMany(status => status.Barbers)
                   .HasForeignKey(barber => barber.AccessStatusId)
                   .HasConstraintName("FK_Barber_AccessStatusId");

            builder.Property(barber => barber.Password)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(barber => barber.Adress)
                   .HasMaxLength(60);

            builder.Property(barber => barber.PassportSeries)
                   .HasMaxLength(8);

            builder.Property(barber => barber.PassportNumber)
                   .HasMaxLength(15);

            builder.Property(barber => barber.BirthDate)
                   .HasColumnType("date");

            //new BarberSeeder().Seed(builder);
        }
    }
}
