using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrimeDeRisque",
                table: "Taches",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrimeObjectif",
                table: "Taches",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fichier = table.Column<byte[]>(type: "LONGBLOB", nullable: false),
                    Debut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Fin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Debut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Fin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conges_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PostePrincipalId = table.Column<int>(type: "int", nullable: false),
                    SalaireDeBase = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrats_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrats_Postes_PostePrincipalId",
                        column: x => x.PostePrincipalId,
                        principalTable: "Postes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeuresSup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantite = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeuresSup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeuresSup_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Primes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Taux = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Retards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Debut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Fin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retards_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Retenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Taux = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retenues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContratPostesComplementaires",
                columns: table => new
                {
                    ContratId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratPostesComplementaires", x => new { x.ContratId, x.PosteId });
                    table.ForeignKey(
                        name: "FK_ContratPostesComplementaires_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratPostesComplementaires_Postes_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Postes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContratPrimes",
                columns: table => new
                {
                    ContratId = table.Column<int>(type: "int", nullable: false),
                    PrimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratPrimes", x => new { x.ContratId, x.PrimeId });
                    table.ForeignKey(
                        name: "FK_ContratPrimes_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratPrimes_Primes_PrimeId",
                        column: x => x.PrimeId,
                        principalTable: "Primes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContratRetenues",
                columns: table => new
                {
                    ContratId = table.Column<int>(type: "int", nullable: false),
                    RetenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratRetenues", x => new { x.ContratId, x.RetenueId });
                    table.ForeignKey(
                        name: "FK_ContratRetenues_Contrats_ContratId",
                        column: x => x.ContratId,
                        principalTable: "Contrats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratRetenues_Retenues_RetenueId",
                        column: x => x.RetenueId,
                        principalTable: "Retenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EmployeId",
                table: "Absences",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Conges_EmployeId",
                table: "Conges",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratPostesComplementaires_PosteId",
                table: "ContratPostesComplementaires",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratPrimes_PrimeId",
                table: "ContratPrimes",
                column: "PrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratRetenues_RetenueId",
                table: "ContratRetenues",
                column: "RetenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_EmployeId",
                table: "Contrats",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_PostePrincipalId",
                table: "Contrats",
                column: "PostePrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_HeuresSup_EmployeId",
                table: "HeuresSup",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Retards_EmployeId",
                table: "Retards",
                column: "EmployeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "ContratPostesComplementaires");

            migrationBuilder.DropTable(
                name: "ContratPrimes");

            migrationBuilder.DropTable(
                name: "ContratRetenues");

            migrationBuilder.DropTable(
                name: "HeuresSup");

            migrationBuilder.DropTable(
                name: "Retards");

            migrationBuilder.DropTable(
                name: "Primes");

            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Retenues");

            migrationBuilder.DropColumn(
                name: "PrimeDeRisque",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "PrimeObjectif",
                table: "Taches");
        }
    }
}
