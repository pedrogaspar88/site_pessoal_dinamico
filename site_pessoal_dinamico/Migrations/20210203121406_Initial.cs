using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace site_pessoal_dinamico.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "distincao_premios",
                columns: table => new
                {
                    distincao_premiosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_distincao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distincao_premios", x => x.distincao_premiosId);
                });

            migrationBuilder.CreateTable(
                name: "experiencia_profissional",
                columns: table => new
                {
                    experiencia_profissionalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    funcao = table.Column<string>(nullable: true),
                    empresa = table.Column<string>(nullable: true),
                    descricao_exp = table.Column<string>(nullable: true),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiencia_profissional", x => x.experiencia_profissionalId);
                });

            migrationBuilder.CreateTable(
                name: "formacao",
                columns: table => new
                {
                    formacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_instituicao = table.Column<string>(nullable: true),
                    nome_curso = table.Column<string>(nullable: true),
                    nivel = table.Column<string>(nullable: true),
                    competencias = table.Column<string>(nullable: true),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formacao", x => x.formacaoId);
                });

            migrationBuilder.CreateTable(
                name: "outras_informacoes",
                columns: table => new
                {
                    outras_informacoesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_informacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outras_informacoes", x => x.outras_informacoesId);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    skillsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao_skills = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.skillsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distincao_premios");

            migrationBuilder.DropTable(
                name: "experiencia_profissional");

            migrationBuilder.DropTable(
                name: "formacao");

            migrationBuilder.DropTable(
                name: "outras_informacoes");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
