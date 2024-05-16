using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopApi.Migrations
{
    /// <inheritdoc />
    public partial class pizad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "Name", "PizzaCrust", "PizzaSize", "PizzaTopping", "Price", "stock" },
                values: new object[] { 104, "Paneer , Cheese , Jalapeno , Tomato", "Paneer Pataka", 0, 15, "[2,0,7,6]", null, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 104);
        }
    }
}
