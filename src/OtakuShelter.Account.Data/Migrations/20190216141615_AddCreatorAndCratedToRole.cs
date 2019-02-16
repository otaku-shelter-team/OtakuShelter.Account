using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtakuShelter.Account.Migrations
{
    public partial class AddCreatorAndCratedToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "creatorid",
                table: "roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_roles_creatorid",
                table: "roles",
                column: "creatorid");

            migrationBuilder.AddForeignKey(
                name: "FK_creator_roles",
                table: "roles",
                column: "creatorid",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creator_roles",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_creatorid",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "created",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "creatorid",
                table: "roles");
        }
    }
}
