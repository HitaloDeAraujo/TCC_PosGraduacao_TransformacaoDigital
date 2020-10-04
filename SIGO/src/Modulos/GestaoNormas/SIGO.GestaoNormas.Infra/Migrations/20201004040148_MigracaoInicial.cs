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
                name: "Repositorios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<string>(type: "longtext", maxLength: 36, nullable: false),
                    URL = table.Column<string>(type: "longtext", nullable: false),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositorios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Normas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<Guid>(maxLength: 36, nullable: false),
                    URL = table.Column<string>(type: "longtext", nullable: false),
                    Titulo = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", maxLength: 200, nullable: false),
                    RepositorioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Normas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Normas_Repositorios_RepositorioID",
                        column: x => x.RepositorioID,
                        principalTable: "Repositorios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Repositorios",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Nome", "URL" },
                values: new object[] { 1, new DateTime(2020, 10, 4, 1, 1, 47, 748, DateTimeKind.Local).AddTicks(4077), null, "Repositório de Hitalo de Araujo", "4b1a7128-2c66-482a-8117-0faba2b69c40", "Hitalo de Araujo", "https://github.com/HitaloDeAraujo" });

            migrationBuilder.InsertData(
                table: "Normas",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "RepositorioID", "Titulo", "URL" },
                values: new object[] { 1, new DateTime(2020, 10, 4, 1, 1, 47, 750, DateTimeKind.Local).AddTicks(8232), null, "Norma de Criação de Agentes de Conversação criada por Hitalo de Araujo", new Guid("1803e4a4-ce59-4abb-a004-0a1a3a2391f7"), 1, "Norma de Criação de Agentes de Conversação", "https://github.com/HitaloDeAraujo/AgenteConversacao/blob/master/HITALO%20ARAUJO%20PROJETO%20E%20DESENVOLVIMENTO%20DE%20UM%20ARCABOU%C3%87O%20DE%20AGENTE%20DE%20CONVERSA%C3%87%C3%83O%20-%2011.pdf" });

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
                name: "Repositorios");
        }
    }
}
