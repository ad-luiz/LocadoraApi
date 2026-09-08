using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaDevolvido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Devolvido",
                table: "Locacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devolvido",
                table: "Locacoes");
        }
    }
}
