using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedPrimesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Primes",
                columns: new[] { "Id", "Motif", "Taux" },
                values: new object[,]
                {
            { 1, "Prime de performance / rendement", 0.05 },
            { 2, "Prime de transport", 10000 },
            { 3, "Prime de départ à la retraite", 0.1 },
            { 4, "Prime d'objectifs", 0.07 },
            { 5, "Prime de participation ou d’intéressement", 0.03 },
            { 6, "Prime de Noël", 10000 },
            { 7, "Prime de mobilité / mutation", 50000 },
            { 8, "Prime de fin d’année", 0.05 },
            { 9, "Prime de nourriture / panier", 10000 },
            { 10, "Prime de ponctualité", 50000 },
            { 11, "Prime d’ancienneté", 0.02 },
            { 12, "Prime de risque", 0.06 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 1);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 2);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 3); 
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 4);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 5);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 6); 
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 7);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 8);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 9); 
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 10);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 11);
            migrationBuilder.DeleteData(table: "Primes", keyColumn: "Id", keyValue: 12);
        }

    }
}
