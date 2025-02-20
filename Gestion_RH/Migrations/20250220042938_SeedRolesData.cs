using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Nom" },
            values: new object[,]
            {
                { 1, "Administrateur" },
                { 2, "Salarie" },
                { 3, "Manager" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
