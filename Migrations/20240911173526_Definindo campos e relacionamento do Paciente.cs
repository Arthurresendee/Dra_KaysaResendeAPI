using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class DefinindocamposerelacionamentodoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeAniversario",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "Pacientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 11, 14, 35, 26, 668, DateTimeKind.Local).AddTicks(1692),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 9, 12, 8, 38, 511, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pacientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Pacientes",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDentista",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Pacientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Pacientes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_IdDentista",
                table: "Pacientes",
                column: "IdDentista");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Dentistas_IdDentista",
                table: "Pacientes",
                column: "IdDentista",
                principalTable: "Dentistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Dentistas_IdDentista",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_IdDentista",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IdDentista",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Pacientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 12, 8, 38, 511, DateTimeKind.Local).AddTicks(564),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 11, 14, 35, 26, 668, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pacientes",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAniversario",
                table: "Pacientes",
                type: "SMALLDATETIME",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Pacientes",
                type: "INT",
                nullable: true,
                defaultValue: 18);

            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "Pacientes",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
