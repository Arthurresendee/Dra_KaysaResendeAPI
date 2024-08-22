using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysaResende.Migrations
{
    /// <inheritdoc />
    public partial class CriandoaclassedeUsuarioDoSistemaemapeandoparaobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 22, 13, 18, 29, 733, DateTimeKind.Local).AddTicks(7189),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 20, 1, 14, 21, 282, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.CreateTable(
                name: "UsuariosDoSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeUsuario = table.Column<int>(type: "INT", nullable: true),
                    AcessoDeUsuario = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoDeSexo = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosDoSistema", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDoSistema_AcessoDeUsuario",
                table: "UsuariosDoSistema",
                column: "AcessoDeUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosDoSistema");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 20, 1, 14, 21, 282, DateTimeKind.Local).AddTicks(4047),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 22, 13, 18, 29, 733, DateTimeKind.Local).AddTicks(7189));
        }
    }
}
