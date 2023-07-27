using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiazFrontDeskApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "PackageAreas",
                newName: "MaxCapacity");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "PackageAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 1,
                column: "CurrentCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 2,
                column: "CurrentCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 3,
                column: "CurrentCapacity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "PackageAreas");

            migrationBuilder.RenameColumn(
                name: "MaxCapacity",
                table: "PackageAreas",
                newName: "Capacity");
        }
    }
}
