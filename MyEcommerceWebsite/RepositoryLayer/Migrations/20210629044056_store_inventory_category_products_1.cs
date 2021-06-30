using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class store_inventory_category_products_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryIdRef = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductModel_CategoryModel_CategoryIdRef",
                        column: x => x.CategoryIdRef,
                        principalTable: "CategoryModel",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryModel",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreIdRef = table.Column<int>(type: "int", nullable: false),
                    ProductIdRef = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryModel", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_InventoryModel_ProductModel_ProductIdRef",
                        column: x => x.ProductIdRef,
                        principalTable: "ProductModel",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryModel_Stores_StoreIdRef",
                        column: x => x.StoreIdRef,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryModel_ProductIdRef",
                table: "InventoryModel",
                column: "ProductIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryModel_StoreIdRef",
                table: "InventoryModel",
                column: "StoreIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_CategoryIdRef",
                table: "ProductModel",
                column: "CategoryIdRef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryModel");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "CategoryModel");
        }
    }
}
