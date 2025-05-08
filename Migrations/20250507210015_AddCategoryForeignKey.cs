using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngriEnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_userID",
                table: "Products",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_userID",
                table: "Products",
                column: "userID",
                principalTable: "Users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_userID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_userID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "Products");
        }
    }
}
