using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OtakuShelter.Accounts.Migrations
{
    public partial class RemoveRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_accounts",
                table: "accounts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropIndex(
                name: "IX_accounts_roleid",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "roleid",
                table: "accounts");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "accounts");

            migrationBuilder.AddColumn<int>(
                name: "roleid",
                table: "accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created = table.Column<DateTime>(nullable: false),
                    creatorid = table.Column<int>(nullable: true),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_creator_roles",
                        column: x => x.creatorid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_roleid",
                table: "accounts",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_roles_creatorid",
                table: "roles",
                column: "creatorid");

            migrationBuilder.AddForeignKey(
                name: "FK_role_accounts",
                table: "accounts",
                column: "roleid",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
