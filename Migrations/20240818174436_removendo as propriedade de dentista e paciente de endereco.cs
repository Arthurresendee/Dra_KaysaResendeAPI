using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysaResende.Migrations
{
    /// <inheritdoc />
    public partial class removendoaspropriedadededentistaepacientedeendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Endereco_IdEndereco",
                table: "Dentistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Endereco_IdEndereco",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_IdEndereco",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_IdEndereco",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 18, 14, 44, 36, 168, DateTimeKind.Local).AddTicks(2093),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 6, 14, 11, 42, 24, 984, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Pacientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Dentistas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_EnderecoId",
                table: "Dentistas",
                column: "EnderecoId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentistas_Endereco_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Endereco_EnderecoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_EnderecoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_EnderecoId",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Dentistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 11, 42, 24, 984, DateTimeKind.Local).AddTicks(8853),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 18, 14, 44, 36, 168, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdEndereco",
                table: "Pacientes",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_IdEndereco",
                table: "Dentistas",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dentistas_Endereco_IdEndereco",
                table: "Dentistas",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Endereco_IdEndereco",
                table: "Pacientes",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
