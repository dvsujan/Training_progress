using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace azureproductapp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Piclink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "Piclink", "Price" },
                values: new object[,]
                {
                    { 1, "Gaming Pc", "https://dvsujanstorage.blob.core.windows.net/products/gamingpc.jpeg", 100000.0 },
                    { 2, "PlayStation 5", "https://dvsujanstorage.blob.core.windows.net/products/ps5.jpeg", 50000.0 },
                    { 3, "Mechanical Keyboard", "https://dvsujanstorage.blob.core.windows.net/products/keyboard.jpg", 10000.0 },
                    { 4, "Gaming Mouse", "https://dvsujanstorage.blob.core.windows.net/products/mouse.jpeg", 6000.0 }
                });
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
