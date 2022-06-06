using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notificaciones = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PrioridadTarea = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recordatorio = table.Column<bool>(type: "bit", nullable: false),
                    FechaHoraRecordatorio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarea_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac23"), null, "Actividades Laborales", 50 },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac24"), null, "Actividades Personales", 30 },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac25"), null, "Actividades Familiares", 20 },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac26"), null, "Servicios Públicos", 80 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Alias", "Apellidos", "Nombres", "Notificaciones", "contrasenia", "correo" },
                values: new object[,]
                {
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01"), "jvasquez", "Vásquez Ramos", "José Javier", true, "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609", "jvasquez@hotmail.com" },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac02"), "dvasquez", "Vásquez Ramos", "Daniel Isaias", false, "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609", "dvasquez@hotmail.com" },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac03"), "jbaquedano", "Baquedano", "Juan Carlos", true, "dcab8210b7450c4be24a3341e676d3e3a7b57bfbb87899dc9be4497cb25f7609", "jbaquedano@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaHoraRecordatorio", "PrioridadTarea", "Recordatorio", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac27"), new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac23"), null, new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(2), null, 1, false, "Revisión de documentación SIISAR", new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01") },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac28"), new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac24"), null, new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(26), null, 0, false, "Ver pelicula Batman en HBO", new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac02") },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac29"), new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac25"), null, new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(98), new DateTime(2022, 12, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 0, true, "Viaje Roatán", new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac03") },
                    { new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac30"), new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac26"), null, new DateTime(2022, 6, 5, 18, 44, 29, 922, DateTimeKind.Local).AddTicks(282), new DateTime(2022, 5, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "Pago de energia eléctrica", new Guid("c88ff4bc-6a99-48ee-95f5-848fc205ac01") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_UsuarioId",
                table: "Tarea",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
