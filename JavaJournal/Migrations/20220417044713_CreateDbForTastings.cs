using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavaJournal.Migrations
{
    public partial class CreateDbForTastings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeanPreset",
                columns: table => new
                {
                    BeanPresetId = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PresetName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Roastery = table.Column<string>(type: "TEXT", nullable: true),
                    Origin = table.Column<string>(type: "TEXT", nullable: true),
                    BeanType = table.Column<int>(type: "INTEGER", nullable: false),
                    Roast = table.Column<int>(type: "INTEGER", nullable: false),
                    Grind = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeanPreset", x => x.BeanPresetId);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    ID = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BeanPresetId = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Process_BeanPreset_BeanPresetId",
                        column: x => x.BeanPresetId,
                        principalTable: "BeanPreset",
                        principalColumn: "BeanPresetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TastingEntry",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BeanPresetId = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TastingEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TastingEntry_BeanPreset_BeanPresetId",
                        column: x => x.BeanPresetId,
                        principalTable: "BeanPreset",
                        principalColumn: "BeanPresetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variety",
                columns: table => new
                {
                    ID = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BeanPresetId = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variety", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Variety_BeanPreset_BeanPresetId",
                        column: x => x.BeanPresetId,
                        principalTable: "BeanPreset",
                        principalColumn: "BeanPresetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_BeanPresetId",
                table: "Process",
                column: "BeanPresetId");

            migrationBuilder.CreateIndex(
                name: "IX_TastingEntry_BeanPresetId",
                table: "TastingEntry",
                column: "BeanPresetId");

            migrationBuilder.CreateIndex(
                name: "IX_Variety_BeanPresetId",
                table: "Variety",
                column: "BeanPresetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "TastingEntry");

            migrationBuilder.DropTable(
                name: "Variety");

            migrationBuilder.DropTable(
                name: "BeanPreset");
        }
    }
}
