using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Accounts.Migrations
{
    public partial class Rename_FK_Account_Sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_sessions",
                table: "tokens");

            migrationBuilder.AddForeignKey(
                name: "FK_account_tokens",
                table: "tokens",
                column: "accountid",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_tokens",
                table: "tokens");

            migrationBuilder.AddForeignKey(
                name: "FK_account_sessions",
                table: "tokens",
                column: "accountid",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
