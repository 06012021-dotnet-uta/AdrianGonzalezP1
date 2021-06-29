using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class orders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_UsernameRef",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_ProductIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryIdRef",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryIdRef",
                table: "Products",
                newName: "IX_Products_CategoryIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UsernameRef",
                table: "Customer",
                newName: "IX_Customer_UsernameRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Username");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerIdRef = table.Column<int>(type: "int", nullable: false),
                    StoreIdRef = table.Column<int>(type: "int", nullable: false),
                    ProductIdRef = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerIdRef",
                        column: x => x.CustomerIdRef,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Products_ProductIdRef",
                        column: x => x.ProductIdRef,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Stores_StoreIdRef",
                        column: x => x.StoreIdRef,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerIdRef",
                table: "Order",
                column: "CustomerIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductIdRef",
                table: "Order",
                column: "ProductIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreIdRef",
                table: "Order",
                column: "StoreIdRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Account_UsernameRef",
                table: "Customer",
                column: "UsernameRef",
                principalTable: "Account",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductIdRef",
                table: "Inventory",
                column: "ProductIdRef",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryIdRef",
                table: "Products",
                column: "CategoryIdRef",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Account_UsernameRef",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductIdRef",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryIdRef",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryIdRef",
                table: "Product",
                newName: "IX_Product_CategoryIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UsernameRef",
                table: "Customers",
                newName: "IX_Customers_UsernameRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_UsernameRef",
                table: "Customers",
                column: "UsernameRef",
                principalTable: "Accounts",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_ProductIdRef",
                table: "Inventory",
                column: "ProductIdRef",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryIdRef",
                table: "Product",
                column: "CategoryIdRef",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
