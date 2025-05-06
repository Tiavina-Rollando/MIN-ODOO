using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedRetenuesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                   table: "Retenues",
                   columns: new[] { "Id", "Motif", "Taux" },
                   values: new object[,]
                   {
            { 1, "Absences non justifiées", 0.02 },
            { 2, "Retard", 10000 },
            { 3, "Frais professionnels non remboursés", 0.1 },
            { 4, "Assurance maladie (cotisations OSTIE)", 0.01 },
            { 5, "Cotisations à la sécurité sociale (CNAPS)", 0.01 },
            { 6, "Impôt sur le revenu (IRSA ou IRPP)", 0.15 },
            { 7, "Prêt / avance salariale", 5000 },
            { 8, "Amendes disciplinaires", 0.05 },
            { 9, "Cotisation syndicale", 0.005 },
            { 10, "Frais de matériel", 0.02 }
                   });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 1);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 2);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 3);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 4);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 5);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 6);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 7);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 8);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 9);
            migrationBuilder.DeleteData(table: "Retenues", keyColumn: "Id", keyValue: 10);
        }
    }
}
