using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class AddColorColumnRegionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Region",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "Region");
        }
    }
}
