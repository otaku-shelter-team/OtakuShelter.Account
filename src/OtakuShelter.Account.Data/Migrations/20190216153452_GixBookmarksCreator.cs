using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Account.Migrations
{
    public partial class GixBookmarksCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "creatorid",
                table: "roles",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "creatorid",
                table: "roles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
