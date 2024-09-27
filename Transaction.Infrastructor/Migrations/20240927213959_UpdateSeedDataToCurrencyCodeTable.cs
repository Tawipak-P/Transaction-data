using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataToCurrencyCodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "TD_CurrencyCodes",
                columns: new[] { "Id", "CurrencyCode" },
                values: new object[,]
                {
                    { 1, "USD" },
                    { 2, "EUR" },
                    { 3, "JPY" },
                    { 4, "GBP" },
                    { 5, "AUD" },
                    { 6, "CAD" },
                    { 7, "CHF" },
                    { 8, "CNY" },
                    { 9, "SEK" },
                    { 10, "NZD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TD_CurrencyCodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "TD_Statuses",
                columns: new[] { "Id", "Name", "Prefix" },
                values: new object[,]
                {
                    { 1, null, null },
                    { 2, null, null },
                    { 3, null, null }
                });
        }
    }
}
