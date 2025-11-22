using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapyType",
                table: "TherapyType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Therapy",
                table: "Therapy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Queen",
                table: "Queen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollinationLocation",
                table: "PollinationLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspection",
                table: "Inspection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disease",
                table: "Disease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crop",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyWintering",
                table: "ColonyWintering");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonySwarming",
                table: "ColonySwarming");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyProduct",
                table: "ColonyProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyPollination",
                table: "ColonyPollination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyNote",
                table: "ColonyNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyDisease",
                table: "ColonyDisease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeeColony",
                table: "BeeColony");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiaryStatus",
                table: "ApiaryStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "TherapyType",
                newName: "TherapyTypes");

            migrationBuilder.RenameTable(
                name: "Therapy",
                newName: "Therapies");

            migrationBuilder.RenameTable(
                name: "Queen",
                newName: "Queens");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "PollinationLocation",
                newName: "PollinationLocations");

            migrationBuilder.RenameTable(
                name: "Inspection",
                newName: "Inspections");

            migrationBuilder.RenameTable(
                name: "Disease",
                newName: "Diseases");

            migrationBuilder.RenameTable(
                name: "Crop",
                newName: "Crops");

            migrationBuilder.RenameTable(
                name: "ColonyWintering",
                newName: "ColonyWinterings");

            migrationBuilder.RenameTable(
                name: "ColonySwarming",
                newName: "ColonySwarmings");

            migrationBuilder.RenameTable(
                name: "ColonyProduct",
                newName: "ColonyProducts");

            migrationBuilder.RenameTable(
                name: "ColonyPollination",
                newName: "ColonyPollinations");

            migrationBuilder.RenameTable(
                name: "ColonyNote",
                newName: "ColonyNotes");

            migrationBuilder.RenameTable(
                name: "ColonyDisease",
                newName: "ColonyDiseases");

            migrationBuilder.RenameTable(
                name: "BeeColony",
                newName: "BeeColonies");

            migrationBuilder.RenameTable(
                name: "ApiaryStatus",
                newName: "ApiaryStatuses");

            migrationBuilder.RenameTable(
                name: "Apiary",
                newName: "Apiaries");

            migrationBuilder.RenameIndex(
                name: "IX_User_PositionId",
                table: "Users",
                newName: "IX_Users_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapy_TherapyTypeId",
                table: "Therapies",
                newName: "IX_Therapies_TherapyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapy_InspectionId",
                table: "Therapies",
                newName: "IX_Therapies_InspectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapy_DiseaseId",
                table: "Therapies",
                newName: "IX_Therapies_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Queen_BeeColonyId",
                table: "Queens",
                newName: "IX_Queens_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_PollinationLocation_CropId",
                table: "PollinationLocations",
                newName: "IX_PollinationLocations_CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspection_BeeColonyId",
                table: "Inspections",
                newName: "IX_Inspections_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyWintering_BeeColonyId",
                table: "ColonyWinterings",
                newName: "IX_ColonyWinterings_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonySwarming_BeeColonyId",
                table: "ColonySwarmings",
                newName: "IX_ColonySwarmings_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProduct_UnitId",
                table: "ColonyProducts",
                newName: "IX_ColonyProducts_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProduct_ProductId",
                table: "ColonyProducts",
                newName: "IX_ColonyProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProduct_BeeColonyId",
                table: "ColonyProducts",
                newName: "IX_ColonyProducts_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyPollination_PollinationLocationId",
                table: "ColonyPollinations",
                newName: "IX_ColonyPollinations_PollinationLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyPollination_BeeColonyId",
                table: "ColonyPollinations",
                newName: "IX_ColonyPollinations_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyNote_BeeColonyId",
                table: "ColonyNotes",
                newName: "IX_ColonyNotes_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyDisease_InspectionId",
                table: "ColonyDiseases",
                newName: "IX_ColonyDiseases_InspectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyDisease_DiseaseId",
                table: "ColonyDiseases",
                newName: "IX_ColonyDiseases_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BeeColony_ParentColonyId",
                table: "BeeColonies",
                newName: "IX_BeeColonies_ParentColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_BeeColony_ApiaryId",
                table: "BeeColonies",
                newName: "IX_BeeColonies_ApiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Apiary_OwnerId",
                table: "Apiaries",
                newName: "IX_Apiaries_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Apiary_ApiaryStatusId",
                table: "Apiaries",
                newName: "IX_Apiaries_ApiaryStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapyTypes",
                table: "TherapyTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Therapies",
                table: "Therapies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Queens",
                table: "Queens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollinationLocations",
                table: "PollinationLocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crops",
                table: "Crops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyWinterings",
                table: "ColonyWinterings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonySwarmings",
                table: "ColonySwarmings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyProducts",
                table: "ColonyProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyPollinations",
                table: "ColonyPollinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyNotes",
                table: "ColonyNotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyDiseases",
                table: "ColonyDiseases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeeColonies",
                table: "BeeColonies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiaryStatuses",
                table: "ApiaryStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiaries_ApiaryStatuses_ApiaryStatusId",
                table: "Apiaries",
                column: "ApiaryStatusId",
                principalTable: "ApiaryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apiaries_Users_OwnerId",
                table: "Apiaries",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_Apiaries_ApiaryId",
                table: "BeeColonies",
                column: "ApiaryId",
                principalTable: "Apiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_BeeColonies_ParentColonyId",
                table: "BeeColonies",
                column: "ParentColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDiseases_Diseases_DiseaseId",
                table: "ColonyDiseases",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyDiseases_Inspections_InspectionId",
                table: "ColonyDiseases",
                column: "InspectionId",
                principalTable: "Inspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyNotes_BeeColonies_BeeColonyId",
                table: "ColonyNotes",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyPollinations_BeeColonies_BeeColonyId",
                table: "ColonyPollinations",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyPollinations_PollinationLocations_PollinationLocationId",
                table: "ColonyPollinations",
                column: "PollinationLocationId",
                principalTable: "PollinationLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyProducts_BeeColonies_BeeColonyId",
                table: "ColonyProducts",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
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
                name: "FK_ColonyProducts_Units_UnitId",
                table: "ColonyProducts",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonySwarmings_BeeColonies_BeeColonyId",
                table: "ColonySwarmings",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonyWinterings_BeeColonies_BeeColonyId",
                table: "ColonyWinterings",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_BeeColonies_BeeColonyId",
                table: "Inspections",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollinationLocations_Crops_CropId",
                table: "PollinationLocations",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
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
                name: "FK_Therapies_Inspections_InspectionId",
                table: "Therapies",
                column: "InspectionId",
                principalTable: "Inspections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Therapies_TherapyTypes_TherapyTypeId",
                table: "Therapies",
                column: "TherapyTypeId",
                principalTable: "TherapyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiaries_ApiaryStatuses_ApiaryStatusId",
                table: "Apiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Apiaries_Users_OwnerId",
                table: "Apiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_Apiaries_ApiaryId",
                table: "BeeColonies");

            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_BeeColonies_ParentColonyId",
                table: "BeeColonies");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDiseases_Diseases_DiseaseId",
                table: "ColonyDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyDiseases_Inspections_InspectionId",
                table: "ColonyDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyNotes_BeeColonies_BeeColonyId",
                table: "ColonyNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyPollinations_BeeColonies_BeeColonyId",
                table: "ColonyPollinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyPollinations_PollinationLocations_PollinationLocationId",
                table: "ColonyPollinations");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_BeeColonies_BeeColonyId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Products_ProductId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyProducts_Units_UnitId",
                table: "ColonyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonySwarmings_BeeColonies_BeeColonyId",
                table: "ColonySwarmings");

            migrationBuilder.DropForeignKey(
                name: "FK_ColonyWinterings_BeeColonies_BeeColonyId",
                table: "ColonyWinterings");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_BeeColonies_BeeColonyId",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_PollinationLocations_Crops_CropId",
                table: "PollinationLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_Diseases_DiseaseId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_Inspections_InspectionId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Therapies_TherapyTypes_TherapyTypeId",
                table: "Therapies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapyTypes",
                table: "TherapyTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Therapies",
                table: "Therapies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Queens",
                table: "Queens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollinationLocations",
                table: "PollinationLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inspections",
                table: "Inspections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diseases",
                table: "Diseases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crops",
                table: "Crops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyWinterings",
                table: "ColonyWinterings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonySwarmings",
                table: "ColonySwarmings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyProducts",
                table: "ColonyProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyPollinations",
                table: "ColonyPollinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyNotes",
                table: "ColonyNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColonyDiseases",
                table: "ColonyDiseases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeeColonies",
                table: "BeeColonies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiaryStatuses",
                table: "ApiaryStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "TherapyTypes",
                newName: "TherapyType");

            migrationBuilder.RenameTable(
                name: "Therapies",
                newName: "Therapy");

            migrationBuilder.RenameTable(
                name: "Queens",
                newName: "Queen");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "PollinationLocations",
                newName: "PollinationLocation");

            migrationBuilder.RenameTable(
                name: "Inspections",
                newName: "Inspection");

            migrationBuilder.RenameTable(
                name: "Diseases",
                newName: "Disease");

            migrationBuilder.RenameTable(
                name: "Crops",
                newName: "Crop");

            migrationBuilder.RenameTable(
                name: "ColonyWinterings",
                newName: "ColonyWintering");

            migrationBuilder.RenameTable(
                name: "ColonySwarmings",
                newName: "ColonySwarming");

            migrationBuilder.RenameTable(
                name: "ColonyProducts",
                newName: "ColonyProduct");

            migrationBuilder.RenameTable(
                name: "ColonyPollinations",
                newName: "ColonyPollination");

            migrationBuilder.RenameTable(
                name: "ColonyNotes",
                newName: "ColonyNote");

            migrationBuilder.RenameTable(
                name: "ColonyDiseases",
                newName: "ColonyDisease");

            migrationBuilder.RenameTable(
                name: "BeeColonies",
                newName: "BeeColony");

            migrationBuilder.RenameTable(
                name: "ApiaryStatuses",
                newName: "ApiaryStatus");

            migrationBuilder.RenameTable(
                name: "Apiaries",
                newName: "Apiary");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PositionId",
                table: "User",
                newName: "IX_User_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_TherapyTypeId",
                table: "Therapy",
                newName: "IX_Therapy_TherapyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_InspectionId",
                table: "Therapy",
                newName: "IX_Therapy_InspectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Therapies_DiseaseId",
                table: "Therapy",
                newName: "IX_Therapy_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Queens_BeeColonyId",
                table: "Queen",
                newName: "IX_Queen_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_PollinationLocations_CropId",
                table: "PollinationLocation",
                newName: "IX_PollinationLocation_CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Inspections_BeeColonyId",
                table: "Inspection",
                newName: "IX_Inspection_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyWinterings_BeeColonyId",
                table: "ColonyWintering",
                newName: "IX_ColonyWintering_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonySwarmings_BeeColonyId",
                table: "ColonySwarming",
                newName: "IX_ColonySwarming_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProducts_UnitId",
                table: "ColonyProduct",
                newName: "IX_ColonyProduct_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProducts_ProductId",
                table: "ColonyProduct",
                newName: "IX_ColonyProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyProducts_BeeColonyId",
                table: "ColonyProduct",
                newName: "IX_ColonyProduct_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyPollinations_PollinationLocationId",
                table: "ColonyPollination",
                newName: "IX_ColonyPollination_PollinationLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyPollinations_BeeColonyId",
                table: "ColonyPollination",
                newName: "IX_ColonyPollination_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyNotes_BeeColonyId",
                table: "ColonyNote",
                newName: "IX_ColonyNote_BeeColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyDiseases_InspectionId",
                table: "ColonyDisease",
                newName: "IX_ColonyDisease_InspectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ColonyDiseases_DiseaseId",
                table: "ColonyDisease",
                newName: "IX_ColonyDisease_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_BeeColonies_ParentColonyId",
                table: "BeeColony",
                newName: "IX_BeeColony_ParentColonyId");

            migrationBuilder.RenameIndex(
                name: "IX_BeeColonies_ApiaryId",
                table: "BeeColony",
                newName: "IX_BeeColony_ApiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Apiaries_OwnerId",
                table: "Apiary",
                newName: "IX_Apiary_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Apiaries_ApiaryStatusId",
                table: "Apiary",
                newName: "IX_Apiary_ApiaryStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapyType",
                table: "TherapyType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Therapy",
                table: "Therapy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Queen",
                table: "Queen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollinationLocation",
                table: "PollinationLocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inspection",
                table: "Inspection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disease",
                table: "Disease",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crop",
                table: "Crop",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyWintering",
                table: "ColonyWintering",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonySwarming",
                table: "ColonySwarming",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyProduct",
                table: "ColonyProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyPollination",
                table: "ColonyPollination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyNote",
                table: "ColonyNote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColonyDisease",
                table: "ColonyDisease",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeeColony",
                table: "BeeColony",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiaryStatus",
                table: "ApiaryStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_User_Position_PositionId",
                table: "User",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
