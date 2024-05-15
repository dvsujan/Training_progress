using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class addedPizzaPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Pizzas",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 101,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 102,
                column: "Price",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 103,
                column: "Price",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");
        }
    }
}
