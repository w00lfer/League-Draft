using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueDraft_API.Migrations
{
    public partial class AddRiotId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiotId",
                table: "Champions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiotId",
                table: "Champions");
        }
    }
}
