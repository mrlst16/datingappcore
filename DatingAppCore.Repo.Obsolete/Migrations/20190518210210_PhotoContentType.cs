using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppCore.Repo.Migrations
{
    public partial class PhotoContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PhotoData");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PhotoData",
                nullable: true);
        }
    }
}
