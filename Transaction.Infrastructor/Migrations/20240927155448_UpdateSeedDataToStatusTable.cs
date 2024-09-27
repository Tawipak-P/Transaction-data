using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transaction.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataToStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDataResults");

            migrationBuilder.InsertData(
                table: "TD_Statuses",
                columns: new[] { "Id", "Name", "Prefix" },
                values: new object[,]
                {
                    { 4, "Failed", "R" },
                    { 5, "Finished", "D" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
