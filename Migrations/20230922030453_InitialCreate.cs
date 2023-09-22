using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    UniqueBattleGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BattleDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.UniqueBattleGuid);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    UniquePlayerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerInitials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Handicap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.UniquePlayerGuid);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    UniqueTeamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamScore = table.Column<int>(type: "int", nullable: false)
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
                name: "Battle");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
