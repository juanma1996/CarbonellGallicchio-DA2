using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PsychologistProblematics_IntermediateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PsychologistProblematics",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(nullable: false),
                    ProblematicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistProblematics", x => new { x.PsychologistId, x.ProblematicId });
                    table.ForeignKey(
                        name: "FK_PsychologistProblematics_Problematics_ProblematicId",
                        column: x => x.ProblematicId,
                        principalTable: "Problematics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PsychologistProblematics_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistProblematics_ProblematicId",
                table: "PsychologistProblematics",
                column: "ProblematicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychologistProblematics");
        }
    }
}
