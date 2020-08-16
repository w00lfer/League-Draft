using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueDraft_API.Migrations
{
    public partial class Addchampiontileurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TileIconUrl",
                table: "Champions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TileIconUrl",
                table: "Champions");
        }
    }
}
