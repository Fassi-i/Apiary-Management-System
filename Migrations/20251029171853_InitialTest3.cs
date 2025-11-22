using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InspectionId",
                table: "Therapy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_DiseaseId",
                table: "Therapy",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_InspectionId",
                table: "Therapy",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_TherapyTypeId",
                table: "Therapy",
                column: "TherapyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Queen_BeeColonyId",
                table: "Queen",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_PollinationLocation_CropId",
                table: "PollinationLocation",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_BeeColonyId",
                table: "Inspection",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyWintering_BeeColonyId",
                table: "ColonyWintering",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonySwarming_BeeColonyId",
                table: "ColonySwarming",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyProduct_BeeColonyId",
                table: "ColonyProduct",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyProduct_ProductId",
                table: "ColonyProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyProduct_UnitId",
                table: "ColonyProduct",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyPollination_BeeColonyId",
                table: "ColonyPollination",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyPollination_PollinationLocationId",
                table: "ColonyPollination",
                column: "PollinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyNote_BeeColonyId",
                table: "ColonyNote",
                column: "BeeColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyDisease_DiseaseId",
                table: "ColonyDisease",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyDisease_InspectionId",
                table: "ColonyDisease",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeColony_ApiaryId",
                table: "BeeColony",
                column: "ApiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeColony_ParentColonyId",
                table: "BeeColony",
                column: "ParentColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Apiary_ApiaryStatusId",
                table: "Apiary",
                column: "ApiaryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Apiary_OwnerId",
                table: "Apiary",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiary_ApiaryStatus_ApiaryStatusId",
                table: "Apiary",
                column: "ApiaryStatusId",
                principalTable: "ApiaryStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apiary_User_OwnerId",
                table: "Apiary",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColony_Apiary_ApiaryId",
                table: "BeeColony",
                column: "ApiaryId",
                principalTable: "Apiary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColony_BeeColony_ParentColonyId",
                table: "BeeColony",
                column: "ParentColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDisease_Disease_DiseaseId",
                table: "ColonyDisease",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDisease_Inspection_InspectionId",
                table: "ColonyDisease",
                column: "InspectionId",
                principalTable: "Inspection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyNote_BeeColony_BeeColonyId",
                table: "ColonyNote",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyPollination_BeeColony_BeeColonyId",
                table: "ColonyPollination",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyPollination_PollinationLocation_PollinationLocationId",
                table: "ColonyPollination",
                column: "PollinationLocationId",
                principalTable: "PollinationLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProduct_BeeColony_BeeColonyId",
                table: "ColonyProduct",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProduct_Product_ProductId",
                table: "ColonyProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProduct_Unit_UnitId",
                table: "ColonyProduct",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonySwarming_BeeColony_BeeColonyId",
                table: "ColonySwarming",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyWintering_BeeColony_BeeColonyId",
                table: "ColonyWintering",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspection_BeeColony_BeeColonyId",
                table: "Inspection",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollinationLocation_Crop_CropId",
                table: "PollinationLocation",
                column: "CropId",
                principalTable: "Crop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queen_BeeColony_BeeColonyId",
                table: "Queen",
                column: "BeeColonyId",
                principalTable: "BeeColony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapy_Disease_DiseaseId",
                table: "Therapy",
                column: "DiseaseId",
                principalTable: "Disease",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Therapy_Inspection_InspectionId",
                table: "Therapy",
                column: "InspectionId",
                principalTable: "Inspection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapy_TherapyType_TherapyTypeId",
                table: "Therapy",
                column: "TherapyTypeId",
                principalTable: "TherapyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiary_ApiaryStatus_ApiaryStatusId",
                table: "Apiary");

            migrationBuilder.DropForeignKey(
                name: "FK_Apiary_User_OwnerId",
                table: "Apiary");

            migrationBuilder.DropForeignKey(
                name: "FK_BeeColony_Apiary_ApiaryId",
                table: "BeeColony");

            migrationBuilder.DropForeignKey(
                name: "FK_BeeColony_BeeColony_ParentColonyId",
                table: "BeeColony");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDisease_Disease_DiseaseId",
                table: "ColonyDisease");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDisease_Inspection_InspectionId",
                table: "ColonyDisease");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyNote_BeeColony_BeeColonyId",
                table: "ColonyNote");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyPollination_BeeColony_BeeColonyId",
                table: "ColonyPollination");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyPollination_PollinationLocation_PollinationLocationId",
                table: "ColonyPollination");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProduct_BeeColony_BeeColonyId",
                table: "ColonyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProduct_Product_ProductId",
                table: "ColonyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProduct_Unit_UnitId",
                table: "ColonyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonySwarming_BeeColony_BeeColonyId",
                table: "ColonySwarming");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyWintering_BeeColony_BeeColonyId",
                table: "ColonyWintering");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspection_BeeColony_BeeColonyId",
                table: "Inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_PollinationLocation_Crop_CropId",
                table: "PollinationLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Queen_BeeColony_BeeColonyId",
                table: "Queen");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapy_Disease_DiseaseId",
                table: "Therapy");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapy_Inspection_InspectionId",
                table: "Therapy");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapy_TherapyType_TherapyTypeId",
                table: "Therapy");

            migrationBuilder.DropIndex(
                name: "IX_Therapy_DiseaseId",
                table: "Therapy");

            migrationBuilder.DropIndex(
                name: "IX_Therapy_InspectionId",
                table: "Therapy");

            migrationBuilder.DropIndex(
                name: "IX_Therapy_TherapyTypeId",
                table: "Therapy");

            migrationBuilder.DropIndex(
                name: "IX_Queen_BeeColonyId",
                table: "Queen");

            migrationBuilder.DropIndex(
                name: "IX_PollinationLocation_CropId",
                table: "PollinationLocation");

            migrationBuilder.DropIndex(
                name: "IX_Inspection_BeeColonyId",
                table: "Inspection");

            migrationBuilder.DropIndex(
                name: "IX_ColonyWintering_BeeColonyId",
                table: "ColonyWintering");

            migrationBuilder.DropIndex(
                name: "IX_ColonySwarming_BeeColonyId",
                table: "ColonySwarming");

            migrationBuilder.DropIndex(
                name: "IX_ColonyProduct_BeeColonyId",
                table: "ColonyProduct");

            migrationBuilder.DropIndex(
                name: "IX_ColonyProduct_ProductId",
                table: "ColonyProduct");

            migrationBuilder.DropIndex(
                name: "IX_ColonyProduct_UnitId",
                table: "ColonyProduct");

            migrationBuilder.DropIndex(
                name: "IX_ColonyPollination_BeeColonyId",
                table: "ColonyPollination");

            migrationBuilder.DropIndex(
                name: "IX_ColonyPollination_PollinationLocationId",
                table: "ColonyPollination");

            migrationBuilder.DropIndex(
                name: "IX_ColonyNote_BeeColonyId",
                table: "ColonyNote");

            migrationBuilder.DropIndex(
                name: "IX_ColonyDisease_DiseaseId",
                table: "ColonyDisease");

            migrationBuilder.DropIndex(
                name: "IX_ColonyDisease_InspectionId",
                table: "ColonyDisease");

            migrationBuilder.DropIndex(
                name: "IX_BeeColony_ApiaryId",
                table: "BeeColony");

            migrationBuilder.DropIndex(
                name: "IX_BeeColony_ParentColonyId",
                table: "BeeColony");

            migrationBuilder.DropIndex(
                name: "IX_Apiary_ApiaryStatusId",
                table: "Apiary");

            migrationBuilder.DropIndex(
                name: "IX_Apiary_OwnerId",
                table: "Apiary");

            migrationBuilder.DropColumn(
                name: "InspectionId",
                table: "Therapy");
        }
    }
}
