using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class try12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId1",
                table: "Products",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId1",
                table: "Products",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
