using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PlayableContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropTable(
                name: "AudioContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories");

            migrationBuilder.DropIndex(
                name: "IX_AudioContentCategories_AudioContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropColumn(
                name: "AudioContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropColumn(
                name: "AudioContentId",
                table: "AudioContentCategories");

            migrationBuilder.AddColumn<int>(
                name: "PlayableContentId",
                table: "AudioContentPlaylists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayableContentId",
                table: "AudioContentCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists",
                columns: new[] { "PlayableContentId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories",
                columns: new[] { "CategoryId", "PlayableContentId" });

            migrationBuilder.CreateTable(
                name: "PlayableContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableContents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioContentCategories_PlayableContentId",
                table: "AudioContentCategories",
                column: "PlayableContentId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentCategories_PlayableContents_PlayableContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioContentPlaylists_PlayableContents_PlayableContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropTable(
                name: "PlayableContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories");

            migrationBuilder.DropIndex(
                name: "IX_AudioContentCategories_PlayableContentId",
                table: "AudioContentCategories");

            migrationBuilder.DropColumn(
                name: "PlayableContentId",
                table: "AudioContentPlaylists");

            migrationBuilder.DropColumn(
                name: "PlayableContentId",
                table: "AudioContentCategories");

            migrationBuilder.AddColumn<int>(
                name: "AudioContentId",
                table: "AudioContentPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AudioContentId",
                table: "AudioContentCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentPlaylists",
                table: "AudioContentPlaylists",
                columns: new[] { "AudioContentId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AudioContentCategories",
                table: "AudioContentCategories",
                columns: new[] { "CategoryId", "AudioContentId" });

            migrationBuilder.CreateTable(
                name: "AudioContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioContents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioContentCategories_AudioContentId",
                table: "AudioContentCategories",
                column: "AudioContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                table: "AudioContentCategories",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                table: "AudioContentPlaylists",
                column: "AudioContentId",
                principalTable: "AudioContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
