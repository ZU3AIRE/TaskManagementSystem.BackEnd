using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "DeveloperId", "Email", "IsActive", "Name", "Password", "TaskId" },
                values: new object[,]
                {
                    { 1, "zubair@gmail.com", true, "Zubair Jamil", "123", null },
                    { 2, "gullzaib@yahoo.com", true, "Gullzaib Khan", "123", null },
                    { 3, "usama@bing.com", true, "Usama Akram", "123", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "DeveloperId",
                keyValue: 3);
        }
    }
}
