using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arroba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailUsuarios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    IdProjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicioProjeto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalProjeto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Casa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valorEstimado = table.Column<int>(type: "int", nullable: false),
                    AnoAprovacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroAprovacao = table.Column<int>(type: "int", nullable: false),
                    situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeto", x => x.IdProjeto);
                    table.ForeignKey(
                        name: "FK_projeto_usuario_usuarioIdUsuario",
                        column: x => x.usuarioIdUsuario,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "acao",
                columns: table => new
                {
                    IdAcao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    selecionarProjeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adicionarAcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusAcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    projetoIdProjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acao", x => x.IdAcao);
                    table.ForeignKey(
                        name: "FK_acao_projeto_projetoIdProjeto",
                        column: x => x.projetoIdProjeto,
                        principalTable: "projeto",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anexo",
                columns: table => new
                {
                    IdAnexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaPdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false),
                    projetoIdProjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anexo", x => x.IdAnexo);
                    table.ForeignKey(
                        name: "FK_anexo_projeto_projetoIdProjeto",
                        column: x => x.projetoIdProjeto,
                        principalTable: "projeto",
                        principalColumn: "IdProjeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_acao_projetoIdProjeto",
                table: "acao",
                column: "projetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_anexo_projetoIdProjeto",
                table: "anexo",
                column: "projetoIdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_projeto_usuarioIdUsuario",
                table: "projeto",
                column: "usuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acao");

            migrationBuilder.DropTable(
                name: "anexo");

            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
