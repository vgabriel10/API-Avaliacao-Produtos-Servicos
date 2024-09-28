using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Avaliacao_Produtos_Servicos.Migrations
{
    /// <inheritdoc />
    public partial class removendocolunaroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "UsuariosLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Roles",
                table: "UsuariosLogin",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
