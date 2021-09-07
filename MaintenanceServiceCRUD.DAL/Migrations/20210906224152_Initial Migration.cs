using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenanceServiceCRUD.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Employees");

            migrationBuilder.EnsureSchema(
                name: "MaintenanceServices");

            migrationBuilder.EnsureSchema(
                name: "Vehicles");

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "Employees",
                columns: table => new
                {
                    IdJob = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDescription = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs_IdJob", x => x.IdJob);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                schema: "Vehicles",
                columns: table => new
                {
                    IdTruck = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    LicensePlate = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks_IdVehicle", x => x.IdTruck);
                });

            migrationBuilder.CreateTable(
                name: "TypeTruckMaintenanceServices",
                schema: "MaintenanceServices",
                columns: table => new
                {
                    IdTypeTruckMaintenanceService = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTruckMaintenanceServices_IdTypeTruckMaintenanceService", x => x.IdTypeTruckMaintenanceService);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJob = table.Column<short>(type: "smallint", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    LastName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmployeeNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdTruck = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_IdEmployee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_IdJob",
                        column: x => x.IdJob,
                        principalSchema: "Employees",
                        principalTable: "Jobs",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Trucks_IdTruck",
                        column: x => x.IdTruck,
                        principalSchema: "Vehicles",
                        principalTable: "Trucks",
                        principalColumn: "IdTruck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckMaintenanceServices",
                schema: "MaintenanceServices",
                columns: table => new
                {
                    IdTruckMaintenanceServices = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTruck = table.Column<short>(type: "smallint", nullable: false),
                    IdTypeTruckMaintenanceService = table.Column<byte>(type: "tinyint", nullable: false),
                    Driver = table.Column<short>(type: "smallint", nullable: false),
                    Dispatcher = table.Column<short>(type: "smallint", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Mechanical = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckMaintenanceServices_IdTruckMaintenanceServices", x => x.IdTruckMaintenanceServices);
                    table.ForeignKey(
                        name: "FK_TruckMaintenanceServices_Employees_Dispatcher",
                        column: x => x.Dispatcher,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckMaintenanceServices_Employees_Driver",
                        column: x => x.Driver,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckMaintenanceServices_Employees_Mechanical",
                        column: x => x.Mechanical,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckMaintenanceServices_Vehicles_IdTruck",
                        column: x => x.IdTruck,
                        principalSchema: "Vehicles",
                        principalTable: "Trucks",
                        principalColumn: "IdTruck",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckMaintenanceServices_Vehicles_IdTypeTruckMaintenanceService",
                        column: x => x.IdTypeTruckMaintenanceService,
                        principalSchema: "MaintenanceServices",
                        principalTable: "TypeTruckMaintenanceServices",
                        principalColumn: "IdTypeTruckMaintenanceService",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdJob",
                schema: "Employees",
                table: "Employees",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdTruck",
                schema: "Employees",
                table: "Employees",
                column: "IdTruck");

            migrationBuilder.CreateIndex(
                name: "IX_TruckMaintenanceServices_Dispatcher",
                schema: "MaintenanceServices",
                table: "TruckMaintenanceServices",
                column: "Dispatcher");

            migrationBuilder.CreateIndex(
                name: "IX_TruckMaintenanceServices_Driver",
                schema: "MaintenanceServices",
                table: "TruckMaintenanceServices",
                column: "Driver");

            migrationBuilder.CreateIndex(
                name: "IX_TruckMaintenanceServices_IdTruck",
                schema: "MaintenanceServices",
                table: "TruckMaintenanceServices",
                column: "IdTruck");

            migrationBuilder.CreateIndex(
                name: "IX_TruckMaintenanceServices_IdTypeTruckMaintenanceService",
                schema: "MaintenanceServices",
                table: "TruckMaintenanceServices",
                column: "IdTypeTruckMaintenanceService");

            migrationBuilder.CreateIndex(
                name: "IX_TruckMaintenanceServices_Mechanical",
                schema: "MaintenanceServices",
                table: "TruckMaintenanceServices",
                column: "Mechanical");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckMaintenanceServices",
                schema: "MaintenanceServices");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Employees");

            migrationBuilder.DropTable(
                name: "TypeTruckMaintenanceServices",
                schema: "MaintenanceServices");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "Employees");

            migrationBuilder.DropTable(
                name: "Trucks",
                schema: "Vehicles");
        }
    }
}
