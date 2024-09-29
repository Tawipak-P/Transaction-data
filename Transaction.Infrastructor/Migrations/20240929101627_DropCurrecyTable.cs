using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations.TransactionDb
{
    /// <inheritdoc />
    public partial class DropCurrecyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TD_CurrencyCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TD_CurrencyCodes",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_CurrencyCodes", x => x.CurrencyCode);
                });

            migrationBuilder.InsertData(
                table: "TD_CurrencyCodes",
                columns: new[] { "CurrencyCode", "Id" },
                values: new object[,]
                {
                    { "AUD", 5 },
                    { "CAD", 6 },
                    { "CHF", 7 },
                    { "CNY", 8 },
                    { "EUR", 2 },
                    { "GBP", 4 },
                    { "JPY", 3 },
                    { "NZD", 10 },
                    { "SEK", 9 },
                    { "USD", 1 }
                });
        }
    }
}
