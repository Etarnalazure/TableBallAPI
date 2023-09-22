using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovingUnusedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    UniqueTeamGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.UniqueTeamGuid);
                });
        }
    }
}
