using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentodedentistacomendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Enderecos_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 36, 25, 23, DateTimeKind.Local).AddTicks(1370),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 30, 7, 857, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_IdEndereco",
                table: "Dentistas",
                column: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentistas_Enderecos_IdEndereco",
                table: "Dentistas",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Enderecos_IdEndereco",
                table: "Dentistas");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_IdEndereco",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 30, 7, 857, DateTimeKind.Local).AddTicks(5149),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 36, 25, 23, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Dentistas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_EnderecoId",
                table: "Dentistas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentistas_Enderecos_EnderecoId",
                table: "Dentistas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
