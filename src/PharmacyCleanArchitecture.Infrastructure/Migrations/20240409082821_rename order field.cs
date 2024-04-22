using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyCleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameorderfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivedAt",
                table: "Orders",
                newName: "DeliveredAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveredAt",
                table: "Orders",
                newName: "ReceivedAt");
        }
    }
}
