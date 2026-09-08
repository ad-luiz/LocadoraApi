using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelaLocacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDevolucaoPrevista",
                table: "Locacoes",
                newName: "DataDevolucao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDevolucao",
                table: "Locacoes",
                newName: "DataDevolucaoPrevista");
        }
    }
}
