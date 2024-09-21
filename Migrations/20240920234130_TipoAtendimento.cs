using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSAlunos2024.Migrations
{
    /// <inheritdoc />
    public partial class TipoAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Atendimentos",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Atendimentos");
        }
    }
}
