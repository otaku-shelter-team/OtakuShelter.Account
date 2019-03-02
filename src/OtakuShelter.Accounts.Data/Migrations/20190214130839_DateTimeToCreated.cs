using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Accounts.Migrations
{
    public partial class DateTimeToCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "tokens",
                newName: "created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "created",
                table: "tokens",
                newName: "datetime");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "user" },
                    { 2, "admin" }
                });
        }
    }
}
