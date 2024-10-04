using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Avaliacao_Produtos_Servicos.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandonovarole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "RegisteredUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
