using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD13.Migrations
{
    public partial class ordersfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfectioneryOrder_Order_IdOrder",
                table: "ConfectioneryOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_IdEmployee",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdEmployee",
                table: "Orders",
                newName: "IX_Orders_IdEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdCustomer",
                table: "Orders",
                newName: "IX_Orders_IdCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfectioneryOrder_Orders_IdOrder",
                table: "ConfectioneryOrder",
                column: "IdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customer_IdCustomer",
                table: "Orders",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employee_IdEmployee",
                table: "Orders",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "IdEmpl",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfectioneryOrder_Orders_IdOrder",
                table: "ConfectioneryOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customer_IdCustomer",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employee_IdEmployee",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdEmployee",
                table: "Order",
                newName: "IX_Order_IdEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IdCustomer",
                table: "Order",
                newName: "IX_Order_IdCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfectioneryOrder_Order_IdOrder",
                table: "ConfectioneryOrder",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_IdEmployee",
                table: "Order",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "IdEmpl",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
