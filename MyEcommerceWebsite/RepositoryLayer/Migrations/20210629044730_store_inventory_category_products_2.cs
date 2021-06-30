using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class store_inventory_category_products_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryModel_ProductModel_ProductIdRef",
                table: "InventoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryModel_Stores_StoreIdRef",
                table: "InventoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryIdRef",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryModel",
                table: "InventoryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryModel",
                table: "CategoryModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "InventoryModel",
                newName: "Inventory");

            migrationBuilder.RenameTable(
                name: "CategoryModel",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_ProductModel_CategoryIdRef",
                table: "Product",
                newName: "IX_Product_CategoryIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryModel_StoreIdRef",
                table: "Inventory",
                newName: "IX_Inventory_StoreIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryModel_ProductIdRef",
                table: "Inventory",
                newName: "IX_Inventory_ProductIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_ProductIdRef",
                table: "Inventory",
                column: "ProductIdRef",
                principalTable: "Product",
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
                name: "FK_Inventory_Stores_StoreIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryIdRef",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "ProductModel");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "InventoryModel");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "CategoryModel");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryIdRef",
                table: "ProductModel",
                newName: "IX_ProductModel_CategoryIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_StoreIdRef",
                table: "InventoryModel",
                newName: "IX_InventoryModel_StoreIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_ProductIdRef",
                table: "InventoryModel",
                newName: "IX_InventoryModel_ProductIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryModel",
                table: "InventoryModel",
                column: "InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryModel",
                table: "CategoryModel",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryModel_ProductModel_ProductIdRef",
                table: "InventoryModel",
                column: "ProductIdRef",
                principalTable: "ProductModel",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryModel_Stores_StoreIdRef",
                table: "InventoryModel",
                column: "StoreIdRef",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_CategoryModel_CategoryIdRef",
                table: "ProductModel",
                column: "CategoryIdRef",
                principalTable: "CategoryModel",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
