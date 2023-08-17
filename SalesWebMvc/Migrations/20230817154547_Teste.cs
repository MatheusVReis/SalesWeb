using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_SalesRecord_StatusId",
                table: "SalesRecord");

            migrationBuilder.DropIndex(
                name: "IX_SalesRecord_StatusId",
                table: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "SalesRecord",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SalesRecord",
                newName: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecord_StatusId",
                table: "SalesRecord",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_SalesRecord_StatusId",
                table: "SalesRecord",
                column: "StatusId",
                principalTable: "SalesRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
