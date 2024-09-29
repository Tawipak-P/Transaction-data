using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations.TransactionDb
{
    /// <inheritdoc />
    public partial class AddNewCurrecyTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TD_CurrencyCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_CurrencyCodes", x => x.Id);
                });

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
            migrationBuilder.DropTable(
                name: "TD_CurrencyCodes");
        }
    }
}
