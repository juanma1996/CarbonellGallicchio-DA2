using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CategoryPlaylistIntermediateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Categories_CategoryId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Playlists");

            migrationBuilder.CreateTable(
                name: "CategoryPlaylists",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPlaylists", x => new { x.CategoryId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_CategoryPlaylists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryPlaylists_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPlaylists_PlaylistId",
                table: "CategoryPlaylists",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPlaylists");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Playlists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Categories_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
