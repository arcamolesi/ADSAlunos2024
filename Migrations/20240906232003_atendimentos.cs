using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSAlunos2024.Migrations
{
    /// <inheritdoc />
    public partial class atendimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoid = table.Column<int>(type: "int", nullable: true),
                    salaid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Alunos_alunoid",
                        column: x => x.alunoid,
                        principalTable: "Alunos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Atendimentos_Salas_salaid",
                        column: x => x.salaid,
                        principalTable: "Salas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_alunoid",
                table: "Atendimentos",
                column: "alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_salaid",
                table: "Atendimentos",
                column: "salaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");
        }
    }
}
