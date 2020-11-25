using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppCore.Repo.Migrations
{
    public partial class RestructureReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationID1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ConversationID1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserReviewBadges");

            migrationBuilder.DropColumn(
                name: "ConversationID1",
                table: "Messages");

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewBadgeTemplateID",
                table: "UserReviewBadges",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ReviewBadgeTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    ClientID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewBadgeTemplates", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewBadges_ReviewBadgeTemplateID",
                table: "UserReviewBadges",
                column: "ReviewBadgeTemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviewBadges_ReviewBadgeTemplates_ReviewBadgeTemplateID",
                table: "UserReviewBadges",
                column: "ReviewBadgeTemplateID",
                principalTable: "ReviewBadgeTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviewBadges_ReviewBadgeTemplates_ReviewBadgeTemplateID",
                table: "UserReviewBadges");

            migrationBuilder.DropTable(
                name: "ReviewBadgeTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserReviewBadges_ReviewBadgeTemplateID",
                table: "UserReviewBadges");

            migrationBuilder.DropColumn(
                name: "ReviewBadgeTemplateID",
                table: "UserReviewBadges");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserReviewBadges",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationID1",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationID1",
                table: "Messages",
                column: "ConversationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationID1",
                table: "Messages",
                column: "ConversationID1",
                principalTable: "Conversations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
