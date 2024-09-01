using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandocampodedescriçãoemEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 4, 51, 26, 243, DateTimeKind.Local).AddTicks(8822),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 48, 18, 969, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Enderecos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 48, 18, 969, DateTimeKind.Local).AddTicks(9948),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 4, 51, 26, 243, DateTimeKind.Local).AddTicks(8822));
        }
    }
}
