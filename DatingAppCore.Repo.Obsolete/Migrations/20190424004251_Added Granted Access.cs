using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppCore.Repo.Migrations
{
    public partial class AddedGrantedAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrantedPermissions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    GrantorID = table.Column<Guid>(nullable: false),
                    GranteeID = table.Column<Guid>(nullable: false),
                    Permissions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantedPermissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GrantedPermissions_Users_GranteeID",
                        column: x => x.GranteeID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GrantedPermissions_Users_GrantorID",
                        column: x => x.GrantorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantedPermissions_GranteeID",
                table: "GrantedPermissions",
                column: "GranteeID");

            migrationBuilder.CreateIndex(
                name: "IX_GrantedPermissions_GrantorID",
                table: "GrantedPermissions",
                column: "GrantorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantedPermissions");
        }
    }
}
