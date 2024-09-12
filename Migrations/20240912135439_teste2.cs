using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 10, 54, 38, 952, DateTimeKind.Local).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 12, 10, 38, 45, 777, DateTimeKind.Local).AddTicks(2271));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 10, 38, 45, 777, DateTimeKind.Local).AddTicks(2271),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 12, 10, 54, 38, 952, DateTimeKind.Local).AddTicks(8840));
        }
    }
}
