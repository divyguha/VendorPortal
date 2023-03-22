using Microsoft.EntityFrameworkCore.Migrations;

namespace VendorApi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PODetails_POMains_POMainId1",
                table: "PODetails");

            migrationBuilder.DropIndex(
                name: "IX_PODetails_POMainId1",
                table: "PODetails");

            migrationBuilder.DropColumn(
                name: "PODetailId",
                table: "POMains");

            migrationBuilder.DropColumn(
                name: "POMainId1",
                table: "PODetails");

            migrationBuilder.CreateIndex(
                name: "IX_PODetails_POMainId",
                table: "PODetails",
                column: "POMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_PODetails_POMains_POMainId",
                table: "PODetails",
                column: "POMainId",
                principalTable: "POMains",
                principalColumn: "POMainId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PODetails_POMains_POMainId",
                table: "PODetails");

            migrationBuilder.DropIndex(
                name: "IX_PODetails_POMainId",
                table: "PODetails");

            migrationBuilder.AddColumn<int>(
                name: "PODetailId",
                table: "POMains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "POMainId1",
                table: "PODetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PODetails_POMainId1",
                table: "PODetails",
                column: "POMainId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PODetails_POMains_POMainId1",
                table: "PODetails",
                column: "POMainId1",
                principalTable: "POMains",
                principalColumn: "POMainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
