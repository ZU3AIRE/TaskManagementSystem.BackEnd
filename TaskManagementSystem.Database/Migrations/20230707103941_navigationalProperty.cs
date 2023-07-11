using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Database.Migrations
{
    /// <inheritdoc />
    public partial class navigationalProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DeveloperId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Developers_TaskId",
                table: "Developers",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Tasks_TaskId",
                table: "Developers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Tasks_TaskId",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_TaskId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Developers");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DeveloperId",
                table: "Tasks",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "DeveloperId");
        }
    }
}
