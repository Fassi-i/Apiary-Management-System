using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiaryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiaries_ApiaryStatuses_ApiaryStatusId",
                table: "Apiaries");

            migrationBuilder.DropTable(
                name: "ApiaryStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Apiaries_ApiaryStatusId",
                table: "Apiaries");

            migrationBuilder.RenameColumn(
                name: "ApiaryStatusId",
                table: "Apiaries",
                newName: "ApiaryStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApiaryStatus",
                table: "Apiaries",
                newName: "ApiaryStatusId");

            migrationBuilder.CreateTable(
                name: "ApiaryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiaryStatuses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Apiaries_ApiaryStatusId",
                table: "Apiaries",
                column: "ApiaryStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiaries_ApiaryStatuses_ApiaryStatusId",
                table: "Apiaries",
                column: "ApiaryStatusId",
                principalTable: "ApiaryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
