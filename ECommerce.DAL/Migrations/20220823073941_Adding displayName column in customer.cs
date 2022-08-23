using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DAL.Migrations
{
    public partial class AddingdisplayNamecolumnincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "DisplayName");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerlastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerFirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerlastName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Customers",
                newName: "CustomerName");
        }
    }
}
