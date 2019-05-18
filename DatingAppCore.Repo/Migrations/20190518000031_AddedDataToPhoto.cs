using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppCore.Repo.Migrations
{
    public partial class AddedDataToPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Photos");
        }
    }
}
