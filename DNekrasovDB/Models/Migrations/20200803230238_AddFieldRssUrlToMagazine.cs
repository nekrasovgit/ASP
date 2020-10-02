using Microsoft.EntityFrameworkCore.Migrations;

namespace DNekrasovDB.Migrations
{
    public partial class AddFieldRssUrlToMagazine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RssUrl",
                table: "Magazines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RssUrl",
                table: "Magazines");
        }
    }
}
