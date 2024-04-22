using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyCleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makediscountedpricenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Pharmacies_PharmacyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PharmacyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PharmacyId",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "ProductInfos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Pharmacies");

            migrationBuilder.AddColumn<Guid>(
                name: "PharmacyId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "ProductInfos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PharmacyId",
                table: "Products",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Pharmacies_PharmacyId",
                table: "Products",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id");
        }
    }
}
