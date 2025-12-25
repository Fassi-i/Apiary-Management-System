using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Product_ProductId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Units_UnitId",
                table: "ColonyProducts");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_ColonyProducts_ProductId",
                table: "ColonyProducts");

            migrationBuilder.DropIndex(
                name: "IX_ColonyProducts_UnitId",
                table: "ColonyProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ColonyProducts");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "ColonyProducts",
                newName: "Product");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "ColonyProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product",
                table: "ColonyProducts",
                newName: "UnitId");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "ColonyProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ColonyProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyProducts_ProductId",
                table: "ColonyProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyProducts_UnitId",
                table: "ColonyProducts",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProducts_Product_ProductId",
                table: "ColonyProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProducts_Units_UnitId",
                table: "ColonyProducts",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
