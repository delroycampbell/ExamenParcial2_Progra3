using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenParcial2_Progra3.Migrations
{
    /// <inheritdoc />
    public partial class fivethmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DificultadId",
                table: "Tarea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dificultad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificultad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_DificultadId",
                table: "Tarea",
                column: "DificultadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea",
                column: "DificultadId",
                principalTable: "Dificultad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea");

            migrationBuilder.DropTable(
                name: "Dificultad");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_DificultadId",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "DificultadId",
                table: "Tarea");
        }
    }
}
