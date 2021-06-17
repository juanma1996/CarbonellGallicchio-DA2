using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Discriminator_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PlayableContents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PlayableContents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "PlayableContents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PlayableContents");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PlayableContents");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "PlayableContents");
        }
    }
}
