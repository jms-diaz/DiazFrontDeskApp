using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiazFrontDeskApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_UserId",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "PackageAreas",
                columns: new[] { "PackageAreaId", "Capacity", "PackageAreaType" },
                values: new object[,]
                {
                    { 1, 10, "Small" },
                    { 2, 5, "Medium" },
                    { 3, 3, "Large" }
                });

            migrationBuilder.InsertData(
                table: "PackageStatus",
                columns: new[] { "PackageStatusId", "PackageStatusName" },
                values: new object[,]
                {
                    { 1, "Stored" },
                    { 2, "Retrieved" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_UserId",
                table: "Packages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Users_UserId",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackageAreas",
                keyColumn: "PackageAreaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PackageStatus",
                keyColumn: "PackageStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageStatus",
                keyColumn: "PackageStatusId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Users_UserId",
                table: "Packages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
