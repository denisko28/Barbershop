using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barbershop.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meaning = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meaning = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PassportSeries = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AccessStatusId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barber_AccessStatusId",
                        column: x => x.AccessStatusId,
                        principalTable: "AccessStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AccessStatusId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AccessStatusId",
                        column: x => x.AccessStatusId,
                        principalTable: "AccessStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                columns: table => new
                {
                    AppointmentsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentService", x => new { x.AppointmentsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_AppointmentService_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Discount", "Duration", "Name", "Price" },
                values: new object[] { 1, 0, 2, "Кроп", 250m });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InvoiceId",
                table: "Appointments",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusId",
                table: "Appointments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_ServicesId",
                table: "AppointmentService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Barbers_AccessStatusId",
                table: "Barbers",
                column: "AccessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccessStatusId",
                table: "Customers",
                column: "AccessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BarberId",
                table: "Invoice",
                column: "BarberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentService");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "AccessStatus");
        }
    }
}
