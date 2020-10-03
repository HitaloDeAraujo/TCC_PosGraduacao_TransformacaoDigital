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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    GUID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true)
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
                values: new object[] { 1, new DateTime(2020, 10, 3, 1, 37, 56, 233, DateTimeKind.Local).AddTicks(3751), null, "Norma Cadastrada" });

            migrationBuilder.InsertData(
                table: "TiposEvento",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Nome" },
                values: new object[] { 2, new DateTime(2020, 10, 3, 1, 37, 56, 234, DateTimeKind.Local).AddTicks(6168), null, "Norma Atualizada" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "AccessFailedCount", "ConcurrencyStamp", "DataCriacao", "DataExclusao", "Email", "EmailConfirmed", "GUID", "Id", "LockoutEnabled", "LockoutEnd", "Matricula", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "1c0ffc2a-e901-42f8-b1f3-46e2be47b64d", new DateTime(2020, 10, 3, 1, 37, 56, 236, DateTimeKind.Local).AddTicks(6848), null, null, false, new Guid("200a868e-33ff-40e0-b315-ff0989f4c16e"), "442b6832-5898-4795-9a0e-a1ae33348af3", false, null, "123", "Hitalo", null, null, null, null, false, "f6d0a1b8-92f0-440d-9e73-0d5e8ef384ed", false, null });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "ID", "DataCriacao", "DataExclusao", "Descricao", "GUID", "Grau", "Nome", "TipoEventoID" },
                values: new object[] { 1, new DateTime(2020, 10, 3, 1, 37, 56, 236, DateTimeKind.Local).AddTicks(216), null, "Desc", "0a08947d-07b9-48a6-9d4a-39378054bc02", 1, "Norma Cadastrada", 1 });

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
