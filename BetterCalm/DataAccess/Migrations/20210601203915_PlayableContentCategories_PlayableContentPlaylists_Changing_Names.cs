using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PlayableContentCategories_PlayableContentPlaylists_Changing_Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_PlayableContents_PlayableContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_PlayableContents_PlayableContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories");

            migrationBuilder.RenameTable(
                name: "AudioContentPlaylists",
                newName: "PlayableContentPlaylists");

            migrationBuilder.RenameTable(
                name: "AudioContentCategories",
                newName: "PlayableContentCategories");

            migrationBuilder.RenameIndex(
                name: "IX_AudioContentPlaylists_PlaylistId",
                table: "PlayableContentPlaylists",
                newName: "IX_PlayableContentPlaylists_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_AudioContentCategories_PlayableContentId",
                table: "PlayableContentCategories",
                newName: "IX_PlayableContentCategories_PlayableContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableContentPlaylists",
                table: "PlayableContentPlaylists",
                columns: new[] { "PlayableContentId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayableContentCategories",
                table: "PlayableContentCategories",
                columns: new[] { "CategoryId", "PlayableContentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableContentCategories_Categories_CategoryId",
                table: "PlayableContentCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableContentCategories_PlayableContents_PlayableContentId",
                table: "PlayableContentCategories",
                column: "PlayableContentId",
                principalTable: "PlayableContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableContentPlaylists_PlayableContents_PlayableContentId",
                table: "PlayableContentPlaylists",
                column: "PlayableContentId",
                principalTable: "PlayableContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableContentPlaylists_Playlists_PlaylistId",
                table: "PlayableContentPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableContentCategories_Categories_CategoryId",
                table: "PlayableContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableContentCategories_PlayableContents_PlayableContentId",
                table: "PlayableContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableContentPlaylists_PlayableContents_PlayableContentId",
                table: "PlayableContentPlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayableContentPlaylists_Playlists_PlaylistId",
                table: "PlayableContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableContentPlaylists",
                table: "PlayableContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayableContentCategories",
                table: "PlayableContentCategories");

            migrationBuilder.RenameTable(
                name: "PlayableContentPlaylists",
                newName: "AudioContentPlaylists");

            migrationBuilder.RenameTable(
                name: "PlayableContentCategories",
                newName: "AudioContentCategories");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableContentPlaylists_PlaylistId",
                table: "AudioContentPlaylists",
                newName: "IX_AudioContentPlaylists_PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayableContentCategories_PlayableContentId",
                table: "AudioContentCategories",
                newName: "IX_AudioContentCategories_PlayableContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists",
                columns: new[] { "PlayableContentId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories",
                columns: new[] { "CategoryId", "PlayableContentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_Categories_CategoryId",
                table: "AudioContentCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_PlayableContents_PlayableContentId",
                table: "AudioContentCategories",
                column: "PlayableContentId",
                principalTable: "PlayableContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_PlayableContents_PlayableContentId",
                table: "AudioContentPlaylists",
                column: "PlayableContentId",
                principalTable: "PlayableContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                table: "AudioContentPlaylists",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
