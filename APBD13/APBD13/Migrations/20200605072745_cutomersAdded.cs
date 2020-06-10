using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD13.Migrations
{
    public partial class cutomersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdClient);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomer",
                table: "Order",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Order_IdCustomer",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Order");
        }
    }
}
