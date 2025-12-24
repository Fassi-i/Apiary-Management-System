using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDiseases_Diseases_DiseaseId",
                table: "ColonyDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Products_ProductId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_Diseases_DiseaseId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TherapyTypes_TherapyTypeId",
                table: "Therapies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapyTypes",
                table: "TherapyTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases");

            migrationBuilder.RenameTable(
                name: "TherapyTypes",
                newName: "TherapyType");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Diseases",
                newName: "Disease");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapyType",
                table: "TherapyType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disease",
                table: "Disease",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDiseases_Disease_DiseaseId",
                table: "ColonyDiseases",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProducts_Product_ProductId",
                table: "ColonyProducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_Disease_DiseaseId",
                table: "Therapies",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TherapyType_TherapyTypeId",
                table: "Therapies",
                column: "TherapyTypeId",
                principalTable: "TherapyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDiseases_Disease_DiseaseId",
                table: "ColonyDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Product_ProductId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_Disease_DiseaseId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TherapyType_TherapyTypeId",
                table: "Therapies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapyType",
                table: "TherapyType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disease",
                table: "Disease");

            migrationBuilder.RenameTable(
                name: "TherapyType",
                newName: "TherapyTypes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Disease",
                newName: "Diseases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapyTypes",
                table: "TherapyTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDiseases_Diseases_DiseaseId",
                table: "ColonyDiseases",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProducts_Products_ProductId",
                table: "ColonyProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_Diseases_DiseaseId",
                table: "Therapies",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TherapyTypes_TherapyTypeId",
                table: "Therapies",
                column: "TherapyTypeId",
                principalTable: "TherapyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
