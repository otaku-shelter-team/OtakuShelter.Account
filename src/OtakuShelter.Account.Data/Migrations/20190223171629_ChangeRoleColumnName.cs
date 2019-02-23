using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Account.Migrations
{
    public partial class ChangeRoleColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "accounts",
                newName: "role");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "accounts",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "accounts",
                newName: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "accounts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }
    }
}
