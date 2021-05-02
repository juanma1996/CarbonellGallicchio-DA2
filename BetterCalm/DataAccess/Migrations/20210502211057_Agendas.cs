using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Agendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    IsAvaible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PsychologistId",
                table: "Agendas",
                column: "PsychologistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
