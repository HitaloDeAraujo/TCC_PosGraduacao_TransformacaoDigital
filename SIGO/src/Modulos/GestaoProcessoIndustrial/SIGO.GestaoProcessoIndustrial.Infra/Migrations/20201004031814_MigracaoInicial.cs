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
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "longtext", maxLength: 50, nullable: false),
                    Grupos = table.Column<string>(nullable: true)
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
                values: new object[] { 1, new DateTime(2020, 10, 4, 0, 18, 14, 40, DateTimeKind.Local).AddTicks(3476), null, "Norma Cadastrada" });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Nome" },
                values: new object[] { 2, new DateTime(2020, 10, 4, 0, 18, 14, 41, DateTimeKind.Local).AddTicks(6244), null, "Norma Atualizada" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Email", "GUID", "Grupos", "Nome" },
                values: new object[] { 1, new DateTime(2020, 10, 4, 0, 18, 14, 43, DateTimeKind.Local).AddTicks(731), null, "123", "c3f2da62-f5e8-4f2f-bbd5-a8f392688f28", "ADMINISTRADOR", "Hitalo" });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Grau", "Nome", "TipoEventoID" },
                values: new object[] { 1, new DateTime(2020, 10, 4, 0, 18, 14, 42, DateTimeKind.Local).AddTicks(8574), null, "Desc", "b2afba3f-fc14-4137-97fc-746ab290fefc", 1, "Norma Cadastrada", 1 });

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
