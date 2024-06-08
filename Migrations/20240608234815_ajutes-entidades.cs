using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Avaliacao_Produtos_Servicos.Migrations
{
    /// <inheritdoc />
    public partial class ajutesentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId",
                table: "Comentarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    ComentarioId = table.Column<int>(type: "integer", nullable: true),
                    Nota = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_AvaliacaoId",
                table: "Comentarios",
                column: "AvaliacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProdutoId",
                table: "Avaliacoes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Avaliacoes_AvaliacaoId",
                table: "Comentarios",
                column: "AvaliacaoId",
                principalTable: "Avaliacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Avaliacoes_AvaliacaoId",
                table: "Comentarios");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_AvaliacaoId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Comentarios");
        }
    }
}
