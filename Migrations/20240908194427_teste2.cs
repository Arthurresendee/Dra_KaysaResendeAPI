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
            migrationBuilder.DropIndex(
                name: "IX_dentista_CPF",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 8, 16, 44, 27, 100, DateTimeKind.Local).AddTicks(2663),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 8, 16, 36, 57, 691, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Dentistas",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldDefaultValue: "00000000000");

            migrationBuilder.CreateIndex(
                name: "IX_dentista_CPF",
                table: "Dentistas",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_dentista_CPF",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 8, 16, 36, 57, 691, DateTimeKind.Local).AddTicks(8752),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 8, 16, 44, 27, 100, DateTimeKind.Local).AddTicks(2663));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Dentistas",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "00000000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.CreateIndex(
                name: "IX_dentista_CPF",
                table: "Dentistas",
                column: "Id",
                unique: true);
        }
    }
}
