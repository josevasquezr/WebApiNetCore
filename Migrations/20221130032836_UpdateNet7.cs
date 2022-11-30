using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNet7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac27"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 29, 21, 28, 36, 72, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac28"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 29, 21, 28, 36, 72, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac29"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 29, 21, 28, 36, 72, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac30"),
                column: "FechaCreacion",
                value: new DateTime(2022, 11, 29, 21, 28, 36, 72, DateTimeKind.Local).AddTicks(9426));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac27"),
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac28"),
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac29"),
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac30"),
                column: "FechaCreacion",
                value: new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(282));
        }
    }
}
