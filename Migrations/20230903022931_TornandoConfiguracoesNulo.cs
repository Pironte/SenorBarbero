using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenorBarbero.Migrations
{
    /// <inheritdoc />
    public partial class TornandoConfiguracoesNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Configuracao_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers",
                column: "Configuracao_Id",
                principalTable: "Configuracoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Configuracao_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers",
                column: "Configuracao_Id",
                principalTable: "Configuracoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
