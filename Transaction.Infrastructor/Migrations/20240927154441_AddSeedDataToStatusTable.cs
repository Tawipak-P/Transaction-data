using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataToStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDataResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "TD_Statuses",
                columns: new[] { "Id", "Name", "Prefix" },
                values: new object[,]
                {
                    { 1, "Approved", "A" },
                    { 2, "Rejected", "R" },
                    { 3, "Done", "D" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDataResults");

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
        }
    }
}
