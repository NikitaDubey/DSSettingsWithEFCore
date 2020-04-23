using Microsoft.EntityFrameworkCore.Migrations;

namespace DSSettings.Migrations
{
    public partial class DURApage_messages_users_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DuraPageMessages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuraPageMessages_UserId",
                table: "DuraPageMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuraPageMessages_Users_UserId",
                table: "DuraPageMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuraPageMessages_Users_UserId",
                table: "DuraPageMessages");

            migrationBuilder.DropIndex(
                name: "IX_DuraPageMessages_UserId",
                table: "DuraPageMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DuraPageMessages");
        }
    }
}
