using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenParcial2_Progra3.Migrations
{
    /// <inheritdoc />
    public partial class fixtarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "Dificultad",
                table: "Tarea");

            migrationBuilder.AlterColumn<int>(
                name: "DificultadId",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea",
                column: "DificultadId",
                principalTable: "Dificultad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea");

            migrationBuilder.AlterColumn<int>(
                name: "DificultadId",
                table: "Tarea",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Dificultad",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Dificultad_DificultadId",
                table: "Tarea",
                column: "DificultadId",
                principalTable: "Dificultad",
                principalColumn: "Id");
        }
    }
}
