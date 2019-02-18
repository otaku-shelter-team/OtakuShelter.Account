using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Account.Migrations
{
    public partial class AddUniqueIndexOnAccountUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_username",
                table: "accounts",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_username",
                table: "accounts");
        }
    }
}
