using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendorApi.Migrations
{
    public partial class migration_24Aug22_year_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnApprovedStatus",
                table: "POMains");

            migrationBuilder.AlterColumn<string>(
                name: "PODate",
                table: "POMains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedStatus",
                table: "POMains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "PODetailId",
                table: "InvoiceMains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SAPVendorCode",
                table: "InvoiceMains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SAPVendorName",
                table: "InvoiceMains",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PODetailId",
                table: "InvoiceMains");

            migrationBuilder.DropColumn(
                name: "SAPVendorCode",
                table: "InvoiceMains");

            migrationBuilder.DropColumn(
                name: "SAPVendorName",
                table: "InvoiceMains");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PODate",
                table: "POMains",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ApprovedStatus",
                table: "POMains",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UnApprovedStatus",
                table: "POMains",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
