using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerTwoGuid",
                table: "Battle",
                newName: "TeamTwoGuid");

            migrationBuilder.RenameColumn(
                name: "PlayerOneGuid",
                table: "Battle",
                newName: "TeamOneGuid");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    UniqueTeamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerOne = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerTwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.UniqueTeamGuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.RenameColumn(
                name: "TeamTwoGuid",
                table: "Battle",
                newName: "PlayerTwoGuid");

            migrationBuilder.RenameColumn(
                name: "TeamOneGuid",
                table: "Battle",
                newName: "PlayerOneGuid");
        }
    }
}
