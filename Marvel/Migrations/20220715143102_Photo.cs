using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marvel.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Stylishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "CallToActs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Callouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Stylishes");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "CallToActs");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Callouts");
        }
    }
}
