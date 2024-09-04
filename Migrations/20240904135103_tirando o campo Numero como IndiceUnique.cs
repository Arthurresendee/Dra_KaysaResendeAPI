using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class tirandoocampoNumerocomoIndiceUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Endereco_Numero",
                table: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 4, 10, 51, 3, 470, DateTimeKind.Local).AddTicks(1021),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 3, 14, 9, 8, 424, DateTimeKind.Local).AddTicks(4963));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 3, 14, 9, 8, 424, DateTimeKind.Local).AddTicks(4963),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 4, 10, 51, 3, 470, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Numero",
                table: "Enderecos",
                column: "Numero",
                unique: true);
        }
    }
}
