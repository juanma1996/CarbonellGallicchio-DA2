using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class AudioContentCategory_AudioContentPlaylist_IntermediateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    AudioUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioContentCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    AudioContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioContentCategories", x => new { x.CategoryId, x.AudioContentId });
                    table.ForeignKey(
                        name: "FK_AudioContentCategories_AudioContents_AudioContentId",
                        column: x => x.AudioContentId,
                        principalTable: "AudioContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AudioContentCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AudioContentPlaylists",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    AudioContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioContentPlaylists", x => new { x.AudioContentId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_AudioContentPlaylists_AudioContents_AudioContentId",
                        column: x => x.AudioContentId,
                        principalTable: "AudioContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AudioContentPlaylists_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioContentCategories_AudioContentId",
                table: "AudioContentCategories",
                column: "AudioContentId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioContentPlaylists_PlaylistId",
                table: "AudioContentPlaylists",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioContentCategories");

            migrationBuilder.DropTable(
                name: "AudioContentPlaylists");

            migrationBuilder.DropTable(
                name: "AudioContents");
        }
    }
}
