using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TherapyType_TherapyTypeId",
                table: "Therapies");

            migrationBuilder.DropTable(
                name: "TherapyType");

            migrationBuilder.DropIndex(
                name: "IX_Therapies_TherapyTypeId",
                table: "Therapies");

            migrationBuilder.DropColumn(
                name: "TherapyTypeId",
                table: "Therapies");

            migrationBuilder.AddColumn<string>(
                name: "TherapyType",
                table: "Therapies",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TherapyType",
                table: "Therapies");

            migrationBuilder.AddColumn<int>(
                name: "TherapyTypeId",
                table: "Therapies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TherapyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapyType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_TherapyTypeId",
                table: "Therapies",
                column: "TherapyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TherapyType_TherapyTypeId",
                table: "Therapies",
                column: "TherapyTypeId",
                principalTable: "TherapyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
