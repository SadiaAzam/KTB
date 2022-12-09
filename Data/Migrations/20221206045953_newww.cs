using Microsoft.EntityFrameworkCore.Migrations;

namespace KTB.Data.Migrations
{
    public partial class newww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_Order_Order_Id",
                table: "Fruit");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_Order_Id",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Fruit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Fruit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fruit_Order_Id",
                table: "Fruit",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruit_Order_Order_Id",
                table: "Fruit",
                column: "Order_Id",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
