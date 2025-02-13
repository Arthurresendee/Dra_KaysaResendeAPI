using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drakaysa.Migrations
{
    /// <inheritdoc />
    public partial class ColocandoIdúnicoemcards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 13, 14, 59, 2, 915, DateTimeKind.Local).AddTicks(2892),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2025, 2, 9, 15, 48, 37, 387, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Id",
                table: "Cards",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_Id",
                table: "Cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 15, 48, 37, 387, DateTimeKind.Local).AddTicks(958),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2025, 2, 13, 14, 59, 2, 915, DateTimeKind.Local).AddTicks(2892));
        }
    }
}
