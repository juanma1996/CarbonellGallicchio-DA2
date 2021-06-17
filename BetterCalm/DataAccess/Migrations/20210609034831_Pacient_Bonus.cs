using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Pacient_Bonus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BonusAmount",
                table: "Pacients",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "BonusApproved",
                table: "Pacients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ConsultationsQuantity",
                table: "Pacients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "GeneratedBonus",
                table: "Pacients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Consultations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Consultations",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusAmount",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "BonusApproved",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "ConsultationsQuantity",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "GeneratedBonus",
                table: "Pacients");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Consultations");
        }
    }
}
