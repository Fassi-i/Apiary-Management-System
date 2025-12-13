using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens");

            migrationBuilder.AlterColumn<int>(
                name: "BeeColonyId",
                table: "Queens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens");

            migrationBuilder.AlterColumn<int>(
                name: "BeeColonyId",
                table: "Queens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Queens_BeeColonies_BeeColonyId",
                table: "Queens",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
