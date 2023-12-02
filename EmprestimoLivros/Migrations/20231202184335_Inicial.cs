using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivros.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LivroEmprestado",
                table: "Emprestimos",
                newName: "FilmeEmprestado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilmeEmprestado",
                table: "Emprestimos",
                newName: "LivroEmprestado");
        }
    }
}
