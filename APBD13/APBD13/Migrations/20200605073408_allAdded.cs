using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD13.Migrations
{
    public partial class allAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmployee",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmpl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmpl);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                table: "Order",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_IdEmployee",
                table: "Order",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "IdEmpl",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_IdEmployee",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Order_IdEmployee",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdEmployee",
                table: "Order");
        }
    }
}
