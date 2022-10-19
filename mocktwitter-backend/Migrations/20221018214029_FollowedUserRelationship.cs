using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mocktwitter_backend.Migrations
{
    public partial class FollowedUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MockTweet_User_UserId",
                table: "MockTweet");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MockTweet",
                table: "MockTweet");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "MockTweet",
                newName: "MockTweets");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserId",
                table: "Users",
                newName: "IX_Users_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MockTweet_UserId",
                table: "MockTweets",
                newName: "IX_MockTweets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockTweets",
                table: "MockTweets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MockTweets_Users_UserId",
                table: "MockTweets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MockTweets_Users_UserId",
                table: "MockTweets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MockTweets",
                table: "MockTweets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "MockTweets",
                newName: "MockTweet");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserId",
                table: "User",
                newName: "IX_User_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MockTweets_UserId",
                table: "MockTweet",
                newName: "IX_MockTweet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MockTweet",
                table: "MockTweet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MockTweet_User_UserId",
                table: "MockTweet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserId",
                table: "User",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
