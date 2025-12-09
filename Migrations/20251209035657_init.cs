using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenParcial2_Progra3.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoTarea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTarea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrioridadMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadMeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaMetaId = table.Column<int>(type: "int", nullable: false),
                    PrioridadMetaId = table.Column<int>(type: "int", nullable: false),
                    EstadoMetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meta_CategoriaMeta_CategoriaMetaId",
                        column: x => x.CategoriaMetaId,
                        principalTable: "CategoriaMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meta_EstadoMeta_EstadoMetaId",
                        column: x => x.EstadoMetaId,
                        principalTable: "EstadoMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meta_PrioridadMeta_PrioridadMetaId",
                        column: x => x.PrioridadMetaId,
                        principalTable: "PrioridadMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dificultad = table.Column<int>(type: "int", nullable: false),
                    TiempoEstimadoHoras = table.Column<double>(type: "float", nullable: false),
                    EstadoTareaId = table.Column<int>(type: "int", nullable: false),
                    MetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarea_EstadoTarea_EstadoTareaId",
                        column: x => x.EstadoTareaId,
                        principalTable: "EstadoTarea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarea_Meta_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meta_CategoriaMetaId",
                table: "Meta",
                column: "CategoriaMetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_EstadoMetaId",
                table: "Meta",
                column: "EstadoMetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_PrioridadMetaId",
                table: "Meta",
                column: "PrioridadMetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_EstadoTareaId",
                table: "Tarea",
                column: "EstadoTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_MetaId",
                table: "Tarea",
                column: "MetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "EstadoTarea");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "CategoriaMeta");

            migrationBuilder.DropTable(
                name: "EstadoMeta");

            migrationBuilder.DropTable(
                name: "PrioridadMeta");
        }
    }
}
