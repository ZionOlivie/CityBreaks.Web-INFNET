using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityBreaks.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Properties",
                newName: "Nome_Propriedade");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Nome_Pais");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "Nome_Cidade");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Nome_Pais" },
                values: new object[,]
                {
                    { 1, "BRA", "Brasil" },
                    { 2, "USA", "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Nome_Cidade" },
                values: new object[,]
                {
                    { 1, 1, "Rio de janeiro" },
                    { 2, 2, "Nova york" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CityId", "Nome_Propriedade", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1, "Copacabana palace", 1500.00m },
                    { 2, 1, "Pousada ipanema", 450.00m },
                    { 3, 2, "Manhattan hotel", 2500.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Nome_Propriedade",
                table: "Properties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nome_Pais",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "Nome_Cidade",
                table: "Cities",
                newName: "Name");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
