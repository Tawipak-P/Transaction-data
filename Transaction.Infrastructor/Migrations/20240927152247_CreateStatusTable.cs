using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class CreateStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TD_Transactions",
                table: "TD_Transactions");

            migrationBuilder.RenameTable(
                name: "TD_Transactions",
                newName: "TD_Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TD_Transactions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TD_Transactions",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "TD_Transactions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TD_Transactions",
                table: "TD_Transactions",
                column: "TransactionId");

            migrationBuilder.CreateTable(
                name: "TD_Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDataResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDataResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TD_Statuses");

            migrationBuilder.DropTable(
                name: "TransactionDataResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TD_Transactions",
                table: "TD_Transactions");

            migrationBuilder.RenameTable(
                name: "TD_Transactions",
                newName: "TD_Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TD_Transactions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TD_Transactions",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "TD_Transactions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TD_Transactions",
                table: "TD_Transactions",
                column: "TransactionId");
        }
    }
}
