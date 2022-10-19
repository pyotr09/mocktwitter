using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mocktwitter_backend.Migrations
{
    public partial class followingseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserUser",
                columns: new[] { "FollowedByUsersId", "FollowingUsersId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserUser",
                keyColumns: new[] { "FollowedByUsersId", "FollowingUsersId" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
