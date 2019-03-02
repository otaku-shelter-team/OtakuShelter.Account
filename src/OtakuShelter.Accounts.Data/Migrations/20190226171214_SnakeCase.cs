using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Accounts.Migrations
{
    public partial class SnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ipaddress",
                table: "tokens",
                newName: "ip_address");

            migrationBuilder.RenameColumn(
                name: "accountid",
                table: "tokens",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_tokens_accountid",
                table: "tokens",
                newName: "IX_tokens_account_id");

            migrationBuilder.RenameColumn(
                name: "passwordhash",
                table: "accounts",
                newName: "password_hash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ip_address",
                table: "tokens",
                newName: "ipaddress");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "tokens",
                newName: "accountid");

            migrationBuilder.RenameIndex(
                name: "IX_tokens_account_id",
                table: "tokens",
                newName: "IX_tokens_accountid");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "accounts",
                newName: "passwordhash");
        }
    }
}
