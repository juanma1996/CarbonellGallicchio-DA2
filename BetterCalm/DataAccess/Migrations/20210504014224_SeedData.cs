using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@gmail.com", "SuperAdmin", "1234" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dormir" },
                    { 2, "Meditar" },
                    { 3, "Música" },
                    { 4, "Cuerpo" }
                });

            migrationBuilder.InsertData(
                table: "Problematics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Depresión" },
                    { 2, "Estrés" },
                    { 3, "Ansiedad" },
                    { 4, "Autoestima" },
                    { 5, "Enojo" },
                    { 6, "Relaciones" },
                    { 7, "Duelo" },
                    { 8, "Otros" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Problematics",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
