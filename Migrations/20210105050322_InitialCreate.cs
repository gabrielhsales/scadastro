using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scadastro.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CI01_ALUNO",
                columns: table => new
                {
                    CI01_ID_ALUNO = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CI01_NM_ALUNO = table.Column<string>(nullable: true),
                    CI01_NU_ALUNO = table.Column<string>(nullable: true),
                    CI01_NM_NACIONALIDADE = table.Column<string>(nullable: true),
                    CI01_NU_CEP = table.Column<string>(nullable: true),
                    CI01_NU_ESTADO = table.Column<string>(nullable: true),
                    CI01_NM_CIDADE = table.Column<string>(nullable: true),
                    CI01_NM_LOGADOURO = table.Column<string>(nullable: true),
                    CI01_NM_EMAIL = table.Column<string>(nullable: true),
                    CI01_NU_TELEFONE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CI01_ALUNO", x => x.CI01_ID_ALUNO);
                });

            migrationBuilder.CreateTable(
                name: "CI02_DOCUMENTOS",
                columns: table => new
                {
                    CI02_ID_DOCUMENTOS = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CI02_ID_ALUNO = table.Column<int>(nullable: false),
                    CI02_NM_MAE = table.Column<string>(nullable: true),
                    CI02_NU_CPF_MAE = table.Column<string>(nullable: true),
                    CI02_NM_PAI = table.Column<string>(nullable: true),
                    CI02_NU_CPF_PAI = table.Column<string>(nullable: true),
                    CI02_NU_TELEFONE_RESPONSAVEL = table.Column<string>(nullable: true),
                    CI02_NU_RG_ALUNO = table.Column<string>(nullable: true),
                    CI02_DT_EMISSAO_RG_ALUNO = table.Column<DateTime>(nullable: false),
                    CI02_DT_NASCIMENTO_ALUNO = table.Column<DateTime>(nullable: false),
                    CI02_TP_SEXO_ALUNO = table.Column<char>(nullable: false),
                    CI02_DH_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CI02_DOCUMENTOS", x => x.CI02_ID_DOCUMENTOS);
                    table.ForeignKey(
                        name: "FK_CI02_DOCUMENTOS_CI01_ALUNO_CI02_ID_ALUNO",
                        column: x => x.CI02_ID_ALUNO,
                        principalTable: "CI01_ALUNO",
                        principalColumn: "CI01_ID_ALUNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CI02_DOCUMENTOS_CI02_ID_ALUNO",
                table: "CI02_DOCUMENTOS",
                column: "CI02_ID_ALUNO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CI02_DOCUMENTOS");

            migrationBuilder.DropTable(
                name: "CI01_ALUNO");
        }
    }
}
