﻿// <auto-generated />
using System;
using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Barbershop.DAL.Migrations
{
    [DbContext(typeof(BarbershopDB))]
    partial class BarbershopDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.Property<int>("AppointmentsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("AppointmentService");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.AccessStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Meaning")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("AccessStatus");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("date");

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.AppointmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Meaning")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Barber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PassportSeries")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccessStatusId");

                    b.ToTable("Barbers");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccessStatusId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Sum")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discount = 0,
                            Duration = 2,
                            Enabled = false,
                            Name = "Кроп",
                            Price = 250m
                        });
                });

            modelBuilder.Entity("AppointmentService", b =>
                {
                    b.HasOne("Barbershop.DAL.Entities.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbershop.DAL.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("Barbershop.DAL.Entities.Barber", "Barber")
                        .WithMany("Appointments")
                        .HasForeignKey("BarberId")
                        .HasConstraintName("FK_Appointments_BarberId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Barbershop.DAL.Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Appointments_CustomerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Barbershop.DAL.Entities.Invoice", "Invoice")
                        .WithOne("Appointment")
                        .HasForeignKey("Barbershop.DAL.Entities.Appointment", "InvoiceId")
                        .HasConstraintName("FK_Appointment_InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbershop.DAL.Entities.AppointmentStatus", "Status")
                        .WithMany("Appointments")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_Appointments_StatusId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("Customer");

                    b.Navigation("Invoice");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Barber", b =>
                {
                    b.HasOne("Barbershop.DAL.Entities.AccessStatus", "AccessStatus")
                        .WithMany("Barbers")
                        .HasForeignKey("AccessStatusId")
                        .HasConstraintName("FK_Barber_AccessStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessStatus");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Customer", b =>
                {
                    b.HasOne("Barbershop.DAL.Entities.AccessStatus", "AccessStatus")
                        .WithMany("Customers")
                        .HasForeignKey("AccessStatusId")
                        .HasConstraintName("FK_Customer_AccessStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessStatus");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Invoice", b =>
                {
                    b.HasOne("Barbershop.DAL.Entities.Barber", "Barber")
                        .WithMany()
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.AccessStatus", b =>
                {
                    b.Navigation("Barbers");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.AppointmentStatus", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Barber", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Barbershop.DAL.Entities.Invoice", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
