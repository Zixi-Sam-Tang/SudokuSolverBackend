using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudokuSolver.Migrations
{
    /// <inheritdoc />
    public partial class RectifyMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Puzzles",
                newName: "PostDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "Puzzles",
                newName: "DatePosted");
        }
    }
}
