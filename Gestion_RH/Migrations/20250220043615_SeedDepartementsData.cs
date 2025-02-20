using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartementsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Departements",
            columns: new[] { "Id", "Nom", "PostVaccant" },
            values: new object[,]
            {
                { 1, "Informatique et Systèmes d’Information", 2 },
                { 2, "Ressources Humaines", 1 },
                { 3, "Comptabilité et Finance", 1 },
                { 4, "Marketing et Communication", 2 }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
