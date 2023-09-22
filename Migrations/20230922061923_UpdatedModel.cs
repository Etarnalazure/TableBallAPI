using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableBallAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
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
            migrationBuilder.DropColumn(
                name: "PlayerOneId",
                table: "Battle");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoId",
                table: "Battle",
                newName: "PlayerGuid");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Battle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Battle");

            migrationBuilder.RenameColumn(
                name: "PlayerGuid",
                table: "Battle",
                newName: "PlayerTwoId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerOneId",
                table: "Battle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
