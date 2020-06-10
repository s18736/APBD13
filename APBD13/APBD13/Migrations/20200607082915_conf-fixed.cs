using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD13.Migrations
{
    public partial class conffixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Confectionery",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Confectionery");
        }
    }
}
