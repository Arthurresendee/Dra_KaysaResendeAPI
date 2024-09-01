using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 30, 7, 857, DateTimeKind.Local).AddTicks(5149),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 28, 52, 551, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 28, 52, 551, DateTimeKind.Local).AddTicks(2301),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 30, 7, 857, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }
    }
}
