using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagementSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class dataseeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "TaskStatusID", "IsActive", "Status" },
                values: new object[,]
                {
                    { 1, true, "Pending" },
                    { 2, true, "Development" },
                    { 3, true, "Closed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "TaskStatusID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "TaskStatusID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskStatuses",
                keyColumn: "TaskStatusID",
                keyValue: 3);
        }
    }
}
