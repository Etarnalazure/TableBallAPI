using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReaddedPlayerTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerGuid",
                table: "Battle",
                newName: "PlayerTwoGuid");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerOneGuid",
                table: "Battle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerOneGuid",
                table: "Battle");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoGuid",
                table: "Battle",
                newName: "PlayerGuid");
        }
    }
}
