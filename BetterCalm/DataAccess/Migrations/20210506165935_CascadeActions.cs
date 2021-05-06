using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class CascadeActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Psychologists_PsychologistId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPlaylists_Categories_CategoryId",
                table: "CategoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPlaylists_Playlists_PlaylistId",
                table: "CategoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Psychologists_PsychologistId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematics_Problematics_ProblematicId",
                table: "PsychologistProblematics");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematics_Psychologists_PsychologistId",
                table: "PsychologistProblematics");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Psychologists_PsychologistId",
                table: "Agendas",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPlaylists_Categories_CategoryId",
                table: "CategoryPlaylists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPlaylists_Playlists_PlaylistId",
                table: "CategoryPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Psychologists_PsychologistId",
                table: "Consultations",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematics_Problematics_ProblematicId",
                table: "PsychologistProblematics",
                column: "ProblematicId",
                principalTable: "Problematics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematics_Psychologists_PsychologistId",
                table: "PsychologistProblematics",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Psychologists_PsychologistId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPlaylists_Categories_CategoryId",
                table: "CategoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPlaylists_Playlists_PlaylistId",
                table: "CategoryPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Psychologists_PsychologistId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematics_Problematics_ProblematicId",
                table: "PsychologistProblematics");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematics_Psychologists_PsychologistId",
                table: "PsychologistProblematics");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Psychologists_PsychologistId",
                table: "Agendas",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPlaylists_Categories_CategoryId",
                table: "CategoryPlaylists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPlaylists_Playlists_PlaylistId",
                table: "CategoryPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Psychologists_PsychologistId",
                table: "Consultations",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematics_Problematics_ProblematicId",
                table: "PsychologistProblematics",
                column: "ProblematicId",
                principalTable: "Problematics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematics_Psychologists_PsychologistId",
                table: "PsychologistProblematics",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
