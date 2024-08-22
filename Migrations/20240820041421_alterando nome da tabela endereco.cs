using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysaResende.Migrations
{
    /// <inheritdoc />
    public partial class alterandonomedatabelaendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Endereco_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Endereco_EnderecoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 1, 14, 21, 282, DateTimeKind.Local).AddTicks(4047),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 18, 14, 44, 36, 168, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentistas_Enderecos_EnderecoId",
                table: "Dentistas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Enderecos_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Enderecos_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Enderecos_EnderecoId",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 18, 14, 44, 36, 168, DateTimeKind.Local).AddTicks(2093),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 20, 1, 14, 21, 282, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentistas_Endereco_EnderecoId",
                table: "Dentistas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Endereco_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }
    }
}
