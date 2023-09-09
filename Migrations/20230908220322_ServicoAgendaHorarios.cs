using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenorBarbero.Migrations
{
    /// <inheritdoc />
    public partial class ServicoAgendaHorarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSocial_Barbearia_Barbearia_Id",
                table: "RedeSocial");

            migrationBuilder.DropTable(
                name: "Configuracoes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Barbearia");

            migrationBuilder.DropIndex(
                name: "IX_RedeSocial_Barbearia_Id",
                table: "RedeSocial");

            migrationBuilder.DropColumn(
                name: "Barbearia_Id",
                table: "RedeSocial");

            migrationBuilder.CreateTable(
                name: "Configuracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Linguagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HabilitaNotificacao = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Horario = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Horarios_Id = table.Column<int>(type: "int", nullable: false),
                    Servico_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barbearia_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_AspNetUsers_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Horarios_Horarios_Id",
                        column: x => x.Horarios_Id,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Servico_Barbearia_Id",
                        column: x => x.Barbearia_Id,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Servico_Servico_Id",
                        column: x => x.Servico_Id,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Barbearia_Id",
                table: "Agenda",
                column: "Barbearia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Horarios_Id",
                table: "Agenda",
                column: "Horarios_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Servico_Id",
                table: "Agenda",
                column: "Servico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Usuario_Id",
                table: "Agenda",
                column: "Usuario_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Configuracao_Configuracao_Id",
                table: "AspNetUsers",
                column: "Configuracao_Id",
                principalTable: "Configuracao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Configuracao_Configuracao_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Configuracao");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.AddColumn<int>(
                name: "Barbearia_Id",
                table: "RedeSocial",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barbearia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearia", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Configuracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HabilitaNotificacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Linguagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Barbearia_Id = table.Column<int>(type: "int", nullable: false),
                    Schedule = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Barbearia_Barbearia_Id",
                        column: x => x.Barbearia_Id,
                        principalTable: "Barbearia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocial_Barbearia_Id",
                table: "RedeSocial",
                column: "Barbearia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Barbearia_Id",
                table: "Schedules",
                column: "Barbearia_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Configuracoes_Configuracao_Id",
                table: "AspNetUsers",
                column: "Configuracao_Id",
                principalTable: "Configuracoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSocial_Barbearia_Barbearia_Id",
                table: "RedeSocial",
                column: "Barbearia_Id",
                principalTable: "Barbearia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
