using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class alt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 48, 18, 969, DateTimeKind.Local).AddTicks(9948),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 36, 25, 23, DateTimeKind.Local).AddTicks(1370));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 36, 25, 23, DateTimeKind.Local).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 48, 18, 969, DateTimeKind.Local).AddTicks(9948));
        }
    }
}
