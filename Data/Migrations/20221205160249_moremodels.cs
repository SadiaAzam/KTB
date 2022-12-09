using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KTB.Data.Migrations
{
    public partial class moremodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_Vendor_Vendor_Id",
                table: "Fruit");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_Vendor_Id",
                table: "Fruit");

            migrationBuilder.RenameColumn(
                name: "Vendor_Id",
                table: "Fruit",
                newName: "Employee_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmployee_Id",
                table: "Fruit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "FruitVendor",
                columns: table => new
                {
                    Fruitsid = table.Column<int>(type: "int", nullable: false),
                    VendorsVendor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitVendor", x => new { x.Fruitsid, x.VendorsVendor_Id });
                    table.ForeignKey(
                        name: "FK_FruitVendor_Fruit_Fruitsid",
                        column: x => x.Fruitsid,
                        principalTable: "Fruit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FruitVendor_Vendor_VendorsVendor_Id",
                        column: x => x.VendorsVendor_Id,
                        principalTable: "Vendor",
                        principalColumn: "Vendor_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_EmployeesEmployee_Id",
                table: "Fruit",
                column: "EmployeesEmployee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FruitVendor_VendorsVendor_Id",
                table: "FruitVendor",
                column: "VendorsVendor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruit_Employee_EmployeesEmployee_Id",
                table: "Fruit",
                column: "EmployeesEmployee_Id",
                principalTable: "Employee",
                principalColumn: "Employee_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_Employee_EmployeesEmployee_Id",
                table: "Fruit");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FruitVendor");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_EmployeesEmployee_Id",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployee_Id",
                table: "Fruit");

            migrationBuilder.RenameColumn(
                name: "Employee_Id",
                table: "Fruit",
                newName: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_Vendor_Id",
                table: "Fruit",
                column: "Vendor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruit_Vendor_Vendor_Id",
                table: "Fruit",
                column: "Vendor_Id",
                principalTable: "Vendor",
                principalColumn: "Vendor_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
