using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.GestaoNormas.Infra.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repositorio",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    GUID = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Normas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    GUID = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    RepositorioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Normas_Repositorio_RepositorioID",
                        column: x => x.RepositorioID,
                        principalTable: "Repositorio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Repositorio",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Nome", "URL" },
                values: new object[] { 1, new DateTime(2020, 10, 1, 22, 11, 58, 867, DateTimeKind.Local).AddTicks(2482), null, "Repositório de Hitalo de Araujo", new Guid("ed1a358d-a4b8-46f1-8b83-f20170d8e199"), "Hitalo de Araujo", "https://github.com/HitaloDeAraujo" });

            migrationBuilder.InsertData(
                table: "Normas",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "RepositorioID", "Titulo", "URL" },
                values: new object[] { 1, new DateTime(2020, 10, 1, 22, 11, 58, 871, DateTimeKind.Local).AddTicks(5876), null, "Norma de Criação de Agentes de Conversação criada por Hitalo de Araujo", new Guid("7fe6494b-c28a-4fa9-809f-bd63c4bc0aa3"), 1, "Norma de Criação de Agentes de Conversação", "https://github.com/HitaloDeAraujo/AgenteConversacao/blob/master/HITALO%20ARAUJO%20PROJETO%20E%20DESENVOLVIMENTO%20DE%20UM%20ARCABOU%C3%87O%20DE%20AGENTE%20DE%20CONVERSA%C3%87%C3%83O%20-%2011.pdf" });

            migrationBuilder.CreateIndex(
                name: "IX_Normas_RepositorioID",
                table: "Normas",
                column: "RepositorioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Normas");

            migrationBuilder.DropTable(
                name: "Repositorio");
        }
    }
}
