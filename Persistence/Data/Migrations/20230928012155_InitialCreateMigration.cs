using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "refresh_token",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 1,
                column: "NombreMedicamento",
                value: "Paracetamol");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 2,
                column: "NombreMedicamento",
                value: "Ibuprofeno");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 3,
                column: "NombreMedicamento",
                value: "Aspirina");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 4,
                column: "NombreMedicamento",
                value: "Amoxicilina");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 5,
                column: "NombreMedicamento",
                value: "Cetirizina");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 6,
                column: "NombreMedicamento",
                value: "Losartan");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 7,
                column: "NombreMedicamento",
                value: "Metformina");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 8,
                column: "NombreMedicamento",
                value: "Atorvastatina");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 9,
                column: "NombreMedicamento",
                value: "Clonazepam");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 10,
                column: "NombreMedicamento",
                value: "Loratadina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "refresh_token",
                keyColumn: "Token",
                keyValue: null,
                column: "Token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "refresh_token",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 1,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 2,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 3,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 4,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 5,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 6,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 7,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 8,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 9,
                column: "NombreMedicamento",
                value: null);

            migrationBuilder.UpdateData(
                table: "medicamento",
                keyColumn: "MedicamentoId",
                keyValue: 10,
                column: "NombreMedicamento",
                value: null);
        }
    }
}
