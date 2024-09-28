using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Infrastructor.Migrations.TempTransactionDb
{
    /// <inheritdoc />
    public partial class UpdateTM_TransactionsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsertTransactionDataResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction");

            migrationBuilder.RenameTable(
                name: "TM_Transaction",
                newName: "TM_Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransfer",
                table: "TM_Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TM_Transactions",
                table: "TM_Transactions",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TM_Transactions",
                table: "TM_Transactions");

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "TM_Transactions");

            migrationBuilder.RenameTable(
                name: "TM_Transactions",
                newName: "TM_Transaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction",
                column: "TransactionId");

            migrationBuilder.CreateTable(
                name: "InsertTransactionDataResults",
                columns: table => new
                {
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
