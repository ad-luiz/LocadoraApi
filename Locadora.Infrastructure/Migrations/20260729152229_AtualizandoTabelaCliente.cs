using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clientes",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "Name");
        }
    }
}
