using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_DemandesConge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DemandeId",
                table: "Conges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DemandesConge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Envoye = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Debut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Fin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesConge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandesConge_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrimesEmploye",
                columns: table => new
                {
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    PrimeId = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimesEmploye", x => new { x.EmployeId, x.PrimeId });
                    table.ForeignKey(
                        name: "FK_PrimesEmploye_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrimesEmploye_Primes_PrimeId",
                        column: x => x.PrimeId,
                        principalTable: "Primes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetenuesEmploye",
                columns: table => new
                {
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    RetenueId = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetenuesEmploye", x => new { x.EmployeId, x.RetenueId });
                    table.ForeignKey(
                        name: "FK_RetenuesEmploye_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetenuesEmploye_Retenues_RetenueId",
                        column: x => x.RetenueId,
                        principalTable: "Retenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Conges_DemandeId",
                table: "Conges",
                column: "DemandeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DemandesConge_EmployeId",
                table: "DemandesConge",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimesEmploye_PrimeId",
                table: "PrimesEmploye",
                column: "PrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RetenuesEmploye_RetenueId",
                table: "RetenuesEmploye",
                column: "RetenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conges_DemandesConge_DemandeId",
                table: "Conges",
                column: "DemandeId",
                principalTable: "DemandesConge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conges_DemandesConge_DemandeId",
                table: "Conges");

            migrationBuilder.DropTable(
                name: "DemandesConge");

            migrationBuilder.DropTable(
                name: "PrimesEmploye");

            migrationBuilder.DropTable(
                name: "RetenuesEmploye");

            migrationBuilder.DropIndex(
                name: "IX_Conges_DemandeId",
                table: "Conges");

            migrationBuilder.DropColumn(
                name: "DemandeId",
                table: "Conges");
        }
    }
}
