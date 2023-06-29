using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMeal.Core.Migrations
{
    public partial class updateEnitites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgLinkUrl",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImgLinkUrl",
                table: "Restaurants");
        }
    }
}
