using Microsoft.EntityFrameworkCore.Migrations;

namespace KTB.Data.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vendor_Id",
                table: "Fruit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Vendor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Vendor_Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruit_Vendor_Vendor_Id",
                table: "Fruit");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Fruit_Vendor_Id",
                table: "Fruit");

            migrationBuilder.DropColumn(
                name: "Vendor_Id",
                table: "Fruit");
        }
    }
}
