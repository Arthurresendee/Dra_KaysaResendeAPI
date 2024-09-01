using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRAKaysa.Migrations
{
    /// <inheritdoc />
    public partial class altx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 3, 28, 52, 551, DateTimeKind.Local).AddTicks(2301),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 8, 30, 23, 17, 42, 510, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Dentistas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Planos",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 30, 23, 17, 42, 510, DateTimeKind.Local).AddTicks(2437),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 9, 1, 3, 28, 52, 551, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Dentistas",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
