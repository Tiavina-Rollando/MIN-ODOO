using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedPostesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Postes",
            columns: new[] { "Id", "Statut", "Nom", "IdDepartement" },
            values: new object[,]
            {
                { 1, false, "Administrateur réseau", 1  },
                { 2, false, "Développeur", 1 },
                { 3, false, "Comptable", 3 },
                { 4, false, "Chargé de recrutement", 2 },
                { 5, true, "Responsable RH", 2 },
                { 6, true, "Directeur financier", 3 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
