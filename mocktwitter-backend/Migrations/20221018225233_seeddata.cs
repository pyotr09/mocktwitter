using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mocktwitter_backend.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "ProjectCanary" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 2, "Trustwell" });

            migrationBuilder.InsertData(
                table: "MockTweets",
                columns: new[] { "Id", "TimeStamp", "Tweet", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 22, 15, 49, 12, 0, DateTimeKind.Local), "Trustwell Certification", 1 },
                    { 2, new DateTime(2022, 9, 22, 15, 25, 0, 0, DateTimeKind.Local), "Continous Monitoring", 1 },
                    { 3, new DateTime(2022, 9, 22, 15, 0, 12, 0, DateTimeKind.Local), "Responsibily Sourced GaS!", 1 },
                    { 4, new DateTime(2022, 9, 22, 14, 49, 12, 0, DateTimeKind.Local), "Measurement economy", 1 },
                    { 5, new DateTime(2022, 9, 21, 9, 0, 12, 0, DateTimeKind.Local), "Methane Concentrations", 1 },
                    { 6, new DateTime(2022, 9, 21, 8, 0, 0, 0, DateTimeKind.Local), "Quantified Total Site Emissions", 1 },
                    { 7, new DateTime(2022, 9, 20, 6, 49, 12, 0, DateTimeKind.Local), "Digital Canopy", 1 },
                    { 8, new DateTime(2022, 9, 20, 1, 49, 12, 0, DateTimeKind.Local), "Methane Moment", 1 },
                    { 9, new DateTime(2022, 9, 19, 21, 49, 12, 0, DateTimeKind.Local), "RSG", 1 },
                    { 10, new DateTime(2022, 9, 22, 16, 25, 0, 0, DateTimeKind.Local), "Verified Methane", 2 },
                    { 11, new DateTime(2022, 9, 22, 15, 20, 0, 0, DateTimeKind.Local), "Responsibily drilled and maintained", 2 },
                    { 12, new DateTime(2022, 9, 22, 14, 30, 12, 0, DateTimeKind.Local), "Demonstrate Water Stewardship", 2 },
                    { 13, new DateTime(2022, 9, 20, 6, 15, 12, 0, DateTimeKind.Local), "Reduce GHG Emissions", 2 },
                    { 14, new DateTime(2022, 9, 20, 1, 0, 12, 0, DateTimeKind.Local), "Emphasize community needs", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MockTweets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
