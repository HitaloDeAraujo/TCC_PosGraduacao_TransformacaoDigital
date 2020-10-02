using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.GestaoProcessoIndustrial.Infra.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposEvento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEvento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<string>(type: "longtext", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<string>(type: "longtext", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", maxLength: 200, nullable: false),
                    Grau = table.Column<int>(type: "int", nullable: false),
                    TipoEventoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Eventos_TiposEvento_TipoEventoID",
                        column: x => x.TipoEventoID,
                        principalTable: "TiposEvento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Nome" },
                values: new object[] { 1, new DateTime(2020, 10, 2, 14, 30, 18, 452, DateTimeKind.Local).AddTicks(7584), null, "Norma Cadastrada" });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Nome" },
                values: new object[] { 2, new DateTime(2020, 10, 2, 14, 30, 18, 455, DateTimeKind.Local).AddTicks(3215), null, "Norma Atualizada" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "GUID", "Nome" },
                values: new object[] { 1, new DateTime(2020, 10, 2, 14, 30, 18, 458, DateTimeKind.Local).AddTicks(9454), null, "cf78be93-bd6a-4bbc-b36a-9850fedd107a", "Hitalo" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Grau", "Nome", "TipoEventoID" },
                values: new object[] { 1, new DateTime(2020, 10, 2, 14, 30, 18, 458, DateTimeKind.Local).AddTicks(2402), null, "Desc", "91ab59ec-a097-4009-bc46-feef53c2bdc7", 1, "Norma Cadastrada", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventoID",
                table: "Eventos",
                column: "TipoEventoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposEvento");
        }
    }
}
