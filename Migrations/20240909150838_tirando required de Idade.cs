using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class tirandorequireddeIdade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 12, 8, 38, 511, DateTimeKind.Local).AddTicks(564),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 8, 17, 34, 30, 706, DateTimeKind.Local).AddTicks(9581));

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Dentistas",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 8, 17, 34, 30, 706, DateTimeKind.Local).AddTicks(9581),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 9, 12, 8, 38, 511, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Dentistas",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);
        }
    }
}
