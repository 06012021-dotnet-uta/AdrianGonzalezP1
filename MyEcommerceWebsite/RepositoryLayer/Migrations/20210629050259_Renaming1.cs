using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Renaming1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stores_StoreIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_ProductIdRef",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreIdRef",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryIdRef",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryIdRef",
                table: "Product",
                newName: "IX_Product_CategoryIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_ProductIdRef",
                table: "Inventory",
                column: "ProductIdRef",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Store_StoreIdRef",
                table: "Inventory",
                column: "StoreIdRef",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductIdRef",
                table: "Order",
                column: "ProductIdRef",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Store_StoreIdRef",
                table: "Order",
                column: "StoreIdRef",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryIdRef",
                table: "Product",
                column: "CategoryIdRef",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_ProductIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Store_StoreIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductIdRef",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Store_StoreIdRef",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryIdRef",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryIdRef",
                table: "Products",
                newName: "IX_Products_CategoryIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductIdRef",
                table: "Inventory",
                column: "ProductIdRef",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stores_StoreIdRef",
                table: "Inventory",
                column: "StoreIdRef",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_ProductIdRef",
                table: "Order",
                column: "ProductIdRef",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreIdRef",
                table: "Order",
                column: "StoreIdRef",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryIdRef",
                table: "Products",
                column: "CategoryIdRef",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
