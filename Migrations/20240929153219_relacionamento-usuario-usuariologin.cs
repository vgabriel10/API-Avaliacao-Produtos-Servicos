using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Avaliacao_Produtos_Servicos.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentousuariousuariologin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuariosLogin",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosLogin_UsuarioId",
                table: "UsuariosLogin",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosLogin_Usuarios_UsuarioId",
                table: "UsuariosLogin",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosLogin_Usuarios_UsuarioId",
                table: "UsuariosLogin");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosLogin_UsuarioId",
                table: "UsuariosLogin");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuariosLogin");
        }
    }
}
