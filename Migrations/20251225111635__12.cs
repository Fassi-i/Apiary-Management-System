using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_Diseases_DiseaseId",
                table: "Therapies");

            migrationBuilder.RenameColumn(
                name: "DiseaseId",
                table: "Therapies",
                newName: "ColonyDiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_DiseaseId",
                table: "Therapies",
                newName: "IX_Therapies_ColonyDiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_ColonyDiseases_ColonyDiseaseId",
                table: "Therapies",
                column: "ColonyDiseaseId",
                principalTable: "ColonyDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_ColonyDiseases_ColonyDiseaseId",
                table: "Therapies");

            migrationBuilder.RenameColumn(
                name: "ColonyDiseaseId",
                table: "Therapies",
                newName: "DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_ColonyDiseaseId",
                table: "Therapies",
                newName: "IX_Therapies_DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_Diseases_DiseaseId",
                table: "Therapies",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
