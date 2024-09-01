using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class criandoindicedenumerodacasaealterandooindicedeCEP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Endereco_CEP",
                table: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 30, 23, 17, 42, 510, DateTimeKind.Local).AddTicks(2437),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 30, 15, 58, 29, 740, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Enderecos",
                type: "INT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CEP",
                table: "Enderecos",
                column: "CEP");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Numero",
                table: "Enderecos",
                column: "Numero",
                unique: true,
                filter: "[Numero] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Endereco_CEP",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Numero",
                table: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 30, 15, 58, 29, 740, DateTimeKind.Local).AddTicks(2262),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 30, 23, 17, 42, 510, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CEP",
                table: "Enderecos",
                column: "CEP",
                unique: true);
        }
    }
}
