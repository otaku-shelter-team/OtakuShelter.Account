using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Accounts.Migrations
{
    public partial class AddAccountEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "accounts",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "accounts");
        }
    }
}
