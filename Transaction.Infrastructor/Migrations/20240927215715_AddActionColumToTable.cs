using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2C2P.AssignmentTest.Infrastructor.Migrations
{
    /// <inheritdoc />
    public partial class AddActionColumToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction");

            migrationBuilder.RenameTable(
                name: "TM_Transaction",
                newName: "TM_Transaction");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TM_Transaction",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TM_Transaction",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNo",
                table: "TM_Transaction",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "TM_Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "TM_Transaction");

            migrationBuilder.RenameTable(
                name: "TM_Transaction",
                newName: "TM_Transaction");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TM_Transaction",
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
                table: "TM_Transaction",
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
                table: "TM_Transaction",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TM_Transaction",
                table: "TM_Transaction",
                column: "TransactionId");
        }
    }
}
