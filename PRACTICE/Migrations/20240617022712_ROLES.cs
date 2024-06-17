using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRACTICE.Migrations
{
    /// <inheritdoc />
    public partial class ROLES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9572ea8a-80fd-4043-b16f-d1f5a6ce8d3d", null, "ADMIN", "ADMIN" },
                    { "eb9d0b28-5d93-4c02-b9af-edf280fbe5da", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9572ea8a-80fd-4043-b16f-d1f5a6ce8d3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb9d0b28-5d93-4c02-b9af-edf280fbe5da");
        }
    }
}
