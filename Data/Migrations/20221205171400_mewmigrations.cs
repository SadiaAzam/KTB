using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KTB.Data.Migrations
{
    public partial class mewmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorsofFruitsid",
                table: "Vendor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Fruit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorsofFruitsid",
                table: "Fruit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorsofFruits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorsofFruits", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorsofFruitsid",
                table: "Vendor",
                column: "VendorsofFruitsid");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_Order_Id",
                table: "Fruit",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_VendorsofFruitsid",
                table: "Fruit",
                column: "VendorsofFruitsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruit_Order_Order_Id",
                table: "Fruit",
                column: "Order_Id",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fruit_VendorsofFruits_VendorsofFruitsid",
                table: "Fruit",
                column: "VendorsofFruitsid",
                principalTable: "VendorsofFruits",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_VendorsofFruits_VendorsofFruitsid",
                table: "Vendor",
                column: "VendorsofFruitsid",
                principalTable: "VendorsofFruits",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_Order_Order_Id",
                table: "Fruit");

            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_VendorsofFruits_VendorsofFruitsid",
                table: "Fruit");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_VendorsofFruits_VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "VendorsofFruits");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_Order_Id",
                table: "Fruit");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_VendorsofFruitsid",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "VendorsofFruitsid",
                table: "Fruit");
        }
    }
}
