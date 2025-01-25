using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class alterandocolunatituloparatitulotopico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Topicos",
                newName: "TituloTopico");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Cards",
                newName: "Texto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 24, 23, 43, 52, 281, DateTimeKind.Local).AddTicks(5321),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2025, 1, 24, 15, 59, 8, 962, DateTimeKind.Local).AddTicks(4314));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TituloTopico",
                table: "Topicos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Cards",
                newName: "Descricao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 24, 15, 59, 8, 962, DateTimeKind.Local).AddTicks(4314),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2025, 1, 24, 23, 43, 52, 281, DateTimeKind.Local).AddTicks(5321));
        }
    }
}
