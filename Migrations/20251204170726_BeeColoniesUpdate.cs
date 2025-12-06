using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class BeeColoniesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_BeeColonies_ParentColonyId",
                table: "BeeColonies");

            migrationBuilder.DropIndex(
                name: "IX_BeeColonies_ParentColonyId",
                table: "BeeColonies");

            migrationBuilder.DropColumn(
                name: "ParentColonyId",
                table: "BeeColonies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentColonyId",
                table: "BeeColonies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_ParentColonyId",
                table: "BeeColonies",
                column: "ParentColonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_BeeColonies_ParentColonyId",
                table: "BeeColonies",
                column: "ParentColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id");
        }
    }
}
