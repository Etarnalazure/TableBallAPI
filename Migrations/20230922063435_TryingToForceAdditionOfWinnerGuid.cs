using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class TryingToForceAdditionOfWinnerGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Battle",
                newName: "WinnerGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WinnerGuid",
                table: "Battle",
                newName: "WinnerId");
        }
    }
}
