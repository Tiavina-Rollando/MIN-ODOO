using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedNationsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Nations",
            columns: new[] { "Id", "Nom", "Peuple", "Drapeau" },
            values: new object[,]
            {
                { 1, "Madagascar", "Malgache", "" },
                { 2, "Maurice", "Mauricien", "" },
                { 3, "Comore", "Comorien", "" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
