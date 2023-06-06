using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHUBBHR.Migrations
{
    /// <inheritdoc />
    public partial class Competencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posicion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    posicion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Posicion__3213E83FA225491D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    posicion_fk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3213E83FA1E73461", x => x.id);
                    table.ForeignKey(
                        name: "FK__Usuarios__posici__4E88ABD4",
                        column: x => x.posicion_fk,
                        principalTable: "Posicion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_posicion_fk",
                table: "Usuarios",
                column: "posicion_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Posicion");
        }
    }
}
