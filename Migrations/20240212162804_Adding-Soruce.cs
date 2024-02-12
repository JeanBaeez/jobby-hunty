using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHunt.Migrations
{
    public partial class AddingSoruce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Jobs");
        }
    }
}
