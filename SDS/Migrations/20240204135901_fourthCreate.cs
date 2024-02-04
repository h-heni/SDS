using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDS.Migrations
{
    /// <inheritdoc />
    public partial class fourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContreBon",
                table: "Caisses");

            migrationBuilder.AlterColumn<string>(
                name: "Poste",
                table: "Rapports",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "ContreBonTotal",
                table: "Caisses",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContreBons",
                columns: table => new
                {
                    ContreBonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valeur = table.Column<float>(type: "float", nullable: false),
                    Nombre = table.Column<float>(type: "float", nullable: false),
                    CaisseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContreBons", x => x.ContreBonId);
                    table.ForeignKey(
                        name: "FK_ContreBons_Caisses_CaisseId",
                        column: x => x.CaisseId,
                        principalTable: "Caisses",
                        principalColumn: "CaisseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ContreBons_CaisseId",
                table: "ContreBons",
                column: "CaisseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContreBons");

            migrationBuilder.DropColumn(
                name: "ContreBonTotal",
                table: "Caisses");

            migrationBuilder.AlterColumn<int>(
                name: "Poste",
                table: "Rapports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "ContreBon",
                table: "Caisses",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
