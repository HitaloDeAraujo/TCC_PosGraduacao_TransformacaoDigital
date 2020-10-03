using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.AssessoriasConsultorias.Infra.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<string>(type: "longtext", maxLength: 36, nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    GUID = table.Column<string>(type: "longtext", maxLength: 36, nullable: false),
                    Nome = table.Column<string>(type: "longtext", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", maxLength: 200, nullable: false),
                    URL = table.Column<string>(type: "longtext", nullable: false),
                    ParceiroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contratos_Parceiros_ParceiroID",
                        column: x => x.ParceiroID,
                        principalTable: "Parceiros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parceiros",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Nome", "Tipo" },
                values: new object[] { 1, new DateTime(2020, 10, 2, 21, 42, 21, 42, DateTimeKind.Local).AddTicks(8966), null, "Descrição 1", "1a5dce47-250a-40c9-9c60-55a819e6c757", "Contrato 1", (short)0 });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Nome", "ParceiroID", "URL" },
                values: new object[] { 1, new DateTime(2020, 10, 2, 21, 42, 21, 45, DateTimeKind.Local).AddTicks(9179), null, "Descrição 1", "dd5f8dab-ebf9-48f0-a6bd-e0feb2971e42", "Contrato 1", 1, "URL" });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ParceiroID",
                table: "Contratos",
                column: "ParceiroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Parceiros");
        }
    }
}
