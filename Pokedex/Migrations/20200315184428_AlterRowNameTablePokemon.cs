using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class AlterRowNameTablePokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemon",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Pokemon",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
