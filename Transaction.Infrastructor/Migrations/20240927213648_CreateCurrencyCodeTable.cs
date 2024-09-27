using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class CreateCurrencyCodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 5);

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

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TD_CurrencyCodes");

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { "Approved", "A" });

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { "Rejected", "R" });

            migrationBuilder.UpdateData(
                table: "TD_Statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Prefix" },
                values: new object[] { "Done", "D" });

            migrationBuilder.InsertData(
                table: "TD_Statuses",
                columns: new[] { "Id", "Name", "Prefix" },
                values: new object[,]
                {
                    { 4, "Failed", "R" },
                    { 5, "Finished", "D" }
                });
        }
    }
}
