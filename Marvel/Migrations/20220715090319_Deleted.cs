using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marvel.Migrations
{
    public partial class Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
