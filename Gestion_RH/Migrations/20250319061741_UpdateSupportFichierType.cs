using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_RH.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupportFichierType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Fichier",
                table: "Supports",
                type: "LONGBLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fichier",
                table: "Supports",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "LONGBLOB")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
