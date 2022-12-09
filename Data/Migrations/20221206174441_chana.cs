using Microsoft.EntityFrameworkCore.Migrations;

namespace KTB.Data.Migrations
{
    public partial class chana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_VendorsofFruits_VendorsofFruitsid",
                table: "Fruit");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_VendorsofFruits_VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_VendorsofFruitsid",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "VendorsofFruitsid",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "VendorsofFruitsid",
                table: "Fruit");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VendorsofFruits",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "FruitId",
                table: "VendorsofFruits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "VendorsofFruits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VendorsofFruits_FruitId",
                table: "VendorsofFruits",
                column: "FruitId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorsofFruits_VendorId",
                table: "VendorsofFruits",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorsofFruits_Fruit_FruitId",
                table: "VendorsofFruits",
                column: "FruitId",
                principalTable: "Fruit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorsofFruits_Vendor_VendorId",
                table: "VendorsofFruits",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Vendor_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorsofFruits_Fruit_FruitId",
                table: "VendorsofFruits");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorsofFruits_Vendor_VendorId",
                table: "VendorsofFruits");

            migrationBuilder.DropIndex(
                name: "IX_VendorsofFruits_FruitId",
                table: "VendorsofFruits");

            migrationBuilder.DropIndex(
                name: "IX_VendorsofFruits_VendorId",
                table: "VendorsofFruits");

            migrationBuilder.DropColumn(
                name: "FruitId",
                table: "VendorsofFruits");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "VendorsofFruits");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VendorsofFruits",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "VendorsofFruitsid",
                table: "Vendor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorsofFruitsid",
                table: "Fruit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorsofFruitsid",
                table: "Vendor",
                column: "VendorsofFruitsid");

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_VendorsofFruitsid",
                table: "Fruit",
                column: "VendorsofFruitsid");

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
    }
}
