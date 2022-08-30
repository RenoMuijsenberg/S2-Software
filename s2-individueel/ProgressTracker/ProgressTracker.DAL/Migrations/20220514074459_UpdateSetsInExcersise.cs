using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressTracker.DAL.Migrations
{
    public partial class UpdateSetsInExcersise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercises");
        }
    }
}
