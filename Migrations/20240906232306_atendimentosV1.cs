using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSAlunos2024.Migrations
{
    /// <inheritdoc />
    public partial class atendimentosV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Alunos_alunoid",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Salas_salaid",
                table: "Atendimentos");

            migrationBuilder.RenameColumn(
                name: "salaid",
                table: "Atendimentos",
                newName: "salaID");

            migrationBuilder.RenameColumn(
                name: "alunoid",
                table: "Atendimentos",
                newName: "alunoID");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_salaid",
                table: "Atendimentos",
                newName: "IX_Atendimentos_salaID");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_alunoid",
                table: "Atendimentos",
                newName: "IX_Atendimentos_alunoID");

            migrationBuilder.AlterColumn<int>(
                name: "salaID",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "alunoID",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Alunos_alunoID",
                table: "Atendimentos",
                column: "alunoID",
                principalTable: "Alunos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Salas_salaID",
                table: "Atendimentos",
                column: "salaID",
                principalTable: "Salas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Alunos_alunoID",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Salas_salaID",
                table: "Atendimentos");

            migrationBuilder.RenameColumn(
                name: "salaID",
                table: "Atendimentos",
                newName: "salaid");

            migrationBuilder.RenameColumn(
                name: "alunoID",
                table: "Atendimentos",
                newName: "alunoid");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_salaID",
                table: "Atendimentos",
                newName: "IX_Atendimentos_salaid");

            migrationBuilder.RenameIndex(
                name: "IX_Atendimentos_alunoID",
                table: "Atendimentos",
                newName: "IX_Atendimentos_alunoid");

            migrationBuilder.AlterColumn<int>(
                name: "salaid",
                table: "Atendimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "alunoid",
                table: "Atendimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Alunos_alunoid",
                table: "Atendimentos",
                column: "alunoid",
                principalTable: "Alunos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Salas_salaid",
                table: "Atendimentos",
                column: "salaid",
                principalTable: "Salas",
                principalColumn: "id");
        }
    }
}
