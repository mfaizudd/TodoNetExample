using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoNetExample.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44a29439-e9a2-4771-b68a-e35ed3fd91ca", "1438ff81-c9a2-4c7d-b119-66366008b874", "Admin", null },
                    { "d94d875e-27dc-4aa9-91a5-2f42f4e8e18e", "11709aef-5c07-430d-b9f5-d7c267b03fcb", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c802c431-a594-47c3-bb6a-ee28700656f7", 0, null, "d85ed058-d523-47a4-b4cd-42dc327f2aef", "admin@admin.com", true, false, null, "Faizud", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEL4qheF3oL22E9BaBg2gbT1PthrS++0/6m9vz4QtlHFVJvfMTJ3mAZiuju8MsWFvyA==", null, false, "22bf3b47-c3ad-497e-8cd8-fcdb5f594b33", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a29439-e9a2-4771-b68a-e35ed3fd91ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d94d875e-27dc-4aa9-91a5-2f42f4e8e18e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c802c431-a594-47c3-bb6a-ee28700656f7");
        }
    }
}
