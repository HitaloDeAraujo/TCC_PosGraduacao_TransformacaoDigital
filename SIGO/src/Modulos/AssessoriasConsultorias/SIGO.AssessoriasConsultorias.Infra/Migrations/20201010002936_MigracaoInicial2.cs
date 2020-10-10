using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGO.AssessoriasConsultorias.Infra.Migrations
{
    public partial class MigracaoInicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GUID",
                table: "Parceiros",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<Guid>(
                name: "GUID",
                table: "Contratos",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldMaxLength: 36);

            migrationBuilder.UpdateData(
                table: "Contratos",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DataCriacao", "GUID" },
                values: new object[] { new DateTime(2020, 10, 9, 21, 29, 36, 247, DateTimeKind.Local).AddTicks(1760), new Guid("b00536b6-73ee-4e5c-8773-70b65eb88956") });

            migrationBuilder.UpdateData(
                table: "Parceiros",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DataCriacao", "GUID" },
                values: new object[] { new DateTime(2020, 10, 9, 21, 29, 36, 244, DateTimeKind.Local).AddTicks(6226), new Guid("93713dc9-63cf-4dee-98ad-610db3c483e8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GUID",
                table: "Parceiros",
                type: "longtext",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<string>(
                name: "GUID",
                table: "Contratos",
                type: "longtext",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldMaxLength: 36);

            migrationBuilder.UpdateData(
                table: "Contratos",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DataCriacao", "GUID" },
                values: new object[] { new DateTime(2020, 10, 2, 21, 42, 21, 45, DateTimeKind.Local).AddTicks(9179), "dd5f8dab-ebf9-48f0-a6bd-e0feb2971e42" });

            migrationBuilder.UpdateData(
                table: "Parceiros",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DataCriacao", "GUID" },
                values: new object[] { new DateTime(2020, 10, 2, 21, 42, 21, 42, DateTimeKind.Local).AddTicks(8966), "1a5dce47-250a-40c9-9c60-55a819e6c757" });
        }
    }
}
