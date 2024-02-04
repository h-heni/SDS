using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.RenameColumn(
                name: "SansPlombFinal",
                table: "Rapports",
                newName: "SansPlombPrice");

            migrationBuilder.RenameColumn(
                name: "SansPlombDiff",
                table: "Rapports",
                newName: "SSP3Diff");

            migrationBuilder.RenameColumn(
                name: "SansPlombDepart",
                table: "Rapports",
                newName: "SSP3Final");

            migrationBuilder.RenameColumn(
                name: "SansPlombCash",
                table: "Rapports",
                newName: "SSP3Cash");

            migrationBuilder.RenameColumn(
                name: "GasoilFinal",
                table: "Rapports",
                newName: "SSP3Depart");

            migrationBuilder.RenameColumn(
                name: "GasoilDiff",
                table: "Rapports",
                newName: "SSP2Diff");

            migrationBuilder.RenameColumn(
                name: "GasoilDepart",
                table: "Rapports",
                newName: "SSP2Final");

            migrationBuilder.RenameColumn(
                name: "GasoilCash",
                table: "Rapports",
                newName: "SSP2Cash");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Rapports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "G1Cash",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G1Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G1Diff",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G1Final",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G2_1Cash",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G2_1Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G2_1Diff",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G2_1Final",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G2_2Cash",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G2_2Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G2_2Diff",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G2_2Final",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G501Cash",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G501Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G501Diff",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "G501Final",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "G50Price",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GasoilPrice",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SSP1Cash",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SSP1Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SSP1Diff",
                table: "Rapports",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SSP1Final",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SSP2Depart",
                table: "Rapports",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Caisses",
                columns: table => new
                {
                    CaisseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Journee = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fond = table.Column<float>(type: "float", nullable: false),
                    Poste1 = table.Column<float>(type: "float", nullable: false),
                    Poste2 = table.Column<float>(type: "float", nullable: false),
                    Poste3 = table.Column<float>(type: "float", nullable: false),
                    Lavage = table.Column<float>(type: "float", nullable: false),
                    Lubrifiant = table.Column<float>(type: "float", nullable: false),
                    Autre = table.Column<float>(type: "float", nullable: false),
                    Espece = table.Column<float>(type: "float", nullable: false),
                    Cheque = table.Column<float>(type: "float", nullable: false),
                    TPE = table.Column<float>(type: "float", nullable: false),
                    Credit = table.Column<float>(type: "float", nullable: false),
                    SNDP = table.Column<float>(type: "float", nullable: false),
                    Depenses = table.Column<float>(type: "float", nullable: false),
                    Filtres = table.Column<float>(type: "float", nullable: false),
                    CreditGerant = table.Column<float>(type: "float", nullable: false),
                    SortieContreBon = table.Column<float>(type: "float", nullable: false),
                    ContreBon = table.Column<float>(type: "float", nullable: false),
                    Total = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caisses", x => x.CaisseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caisses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G1Cash",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G1Depart",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G1Diff",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G1Final",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_1Cash",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_1Depart",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_1Diff",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_1Final",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_2Cash",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_2Depart",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_2Diff",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G2_2Final",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G501Cash",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G501Depart",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G501Diff",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G501Final",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "G50Price",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "GasoilPrice",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "SSP1Cash",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "SSP1Depart",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "SSP1Diff",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "SSP1Final",
                table: "Rapports");

            migrationBuilder.DropColumn(
                name: "SSP2Depart",
                table: "Rapports");

            migrationBuilder.RenameColumn(
                name: "SansPlombPrice",
                table: "Rapports",
                newName: "SansPlombFinal");

            migrationBuilder.RenameColumn(
                name: "SSP3Final",
                table: "Rapports",
                newName: "SansPlombDepart");

            migrationBuilder.RenameColumn(
                name: "SSP3Diff",
                table: "Rapports",
                newName: "SansPlombDiff");

            migrationBuilder.RenameColumn(
                name: "SSP3Depart",
                table: "Rapports",
                newName: "GasoilFinal");

            migrationBuilder.RenameColumn(
                name: "SSP3Cash",
                table: "Rapports",
                newName: "SansPlombCash");

            migrationBuilder.RenameColumn(
                name: "SSP2Final",
                table: "Rapports",
                newName: "GasoilDepart");

            migrationBuilder.RenameColumn(
                name: "SSP2Diff",
                table: "Rapports",
                newName: "GasoilDiff");

            migrationBuilder.RenameColumn(
                name: "SSP2Cash",
                table: "Rapports",
                newName: "GasoilCash");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GasoilPrice = table.Column<float>(type: "float", nullable: false),
                    SansPlombPrice = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
