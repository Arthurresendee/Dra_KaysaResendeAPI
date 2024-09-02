using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class RemovendocampobairrodaentidadeDentista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Dentistas");

            migrationBuilder.RenameColumn(
                name: "DataDeAniversario",
                table: "Dentistas",
                newName: "DataDeNascimento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 12, 54, 45, 590, DateTimeKind.Local).AddTicks(2669),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 4, 51, 26, 243, DateTimeKind.Local).AddTicks(8822));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeNascimento",
                table: "Dentistas",
                newName: "DataDeAniversario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 4, 51, 26, 243, DateTimeKind.Local).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 12, 54, 45, 590, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Dentistas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
