﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
  /// <inheritdoc />
  public partial class InitialMigration : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Drivers",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "TEXT", nullable: false),
            FirstName = table.Column<string>(type: "TEXT", nullable: false),
            LastName = table.Column<string>(type: "TEXT", nullable: false),
            DriversNumber = table.Column<int>(type: "INTEGER", nullable: false),
            DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
            AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            Status = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Drivers", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Achievements",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "TEXT", nullable: false),
            RaceWins = table.Column<int>(type: "INTEGER", nullable: false),
            PolePosition = table.Column<int>(type: "INTEGER", nullable: false),
            FastestLap = table.Column<int>(type: "INTEGER", nullable: false),
            WorrldChampionship = table.Column<int>(type: "INTEGER", nullable: false),
            Driverid = table.Column<Guid>(type: "TEXT", nullable: false),
            AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
            Status = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Achievements", x => x.Id);
            table.ForeignKey(
                      name: "FK_Achievements_Driver",
                      column: x => x.Driverid,
                      principalTable: "Drivers",
                      principalColumn: "Id");
          });

      migrationBuilder.CreateIndex(
          name: "IX_Achievements_Driverid",
          table: "Achievements",
          column: "Driverid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Achievements");

      migrationBuilder.DropTable(
          name: "Drivers");
    }
  }
}
