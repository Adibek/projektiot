using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTManager.Migrations
{
    /// <inheritdoc />
    public partial class TaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "Task",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaskDesc",
                table: "Task",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Task",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "TaskDesc",
                table: "Task");
        }
    }
}
