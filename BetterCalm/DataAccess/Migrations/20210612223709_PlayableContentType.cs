using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PlayableContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PlayableContents");

            migrationBuilder.AddColumn<int>(
                name: "PlayableContentTypeId",
                table: "PlayableContents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayableContentTypes",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableContentTypes", x => x.Type);
                });

            migrationBuilder.InsertData(
                table: "PlayableContentTypes",
                columns: new[] { "Type", "Name" },
                values: new object[] { 1, "Audio" });

            migrationBuilder.InsertData(
                table: "PlayableContentTypes",
                columns: new[] { "Type", "Name" },
                values: new object[] { 2, "Video" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayableContents_PlayableContentTypeId",
                table: "PlayableContents",
                column: "PlayableContentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayableContents_PlayableContentTypes_PlayableContentTypeId",
                table: "PlayableContents",
                column: "PlayableContentTypeId",
                principalTable: "PlayableContentTypes",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayableContents_PlayableContentTypes_PlayableContentTypeId",
                table: "PlayableContents");

            migrationBuilder.DropTable(
                name: "PlayableContentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlayableContents_PlayableContentTypeId",
                table: "PlayableContents");

            migrationBuilder.DropColumn(
                name: "PlayableContentTypeId",
                table: "PlayableContents");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PlayableContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
