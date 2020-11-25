using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppCore.Repo.Migrations
{
    public partial class Addedindexforuserprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserProfileField",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileField_Name_UserID_IsSetting",
                table: "UserProfileField",
                columns: new[] { "Name", "UserID", "IsSetting" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfileField_Name_UserID_IsSetting",
                table: "UserProfileField");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserProfileField",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
