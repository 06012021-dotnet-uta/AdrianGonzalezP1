using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CustomerModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountUsername",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountUsername",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountUsername",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "UsernameRef",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UsernameRef",
                table: "Customers",
                column: "UsernameRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_UsernameRef",
                table: "Customers",
                column: "UsernameRef",
                principalTable: "Accounts",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_UsernameRef",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UsernameRef",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "UsernameRef",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountUsername",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountUsername",
                table: "Customers",
                column: "AccountUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountUsername",
                table: "Customers",
                column: "AccountUsername",
                principalTable: "Accounts",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
