using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class AddOrganizationAuthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthorization",
                table: "UserAuthorization");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "UserAuthorization",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthorization",
                table: "UserAuthorization",
                columns: new[] { "UserId", "BUId", "CompanyId", "RoleId", "ProcessTypeId", "OrganizationId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_OrganizationId",
                table: "UserAuthorization",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthorization_SalesOrganization_OrganizationId",
                table: "UserAuthorization",
                column: "OrganizationId",
                principalTable: "SalesOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthorization_SalesOrganization_OrganizationId",
                table: "UserAuthorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthorization",
                table: "UserAuthorization");

            migrationBuilder.DropIndex(
                name: "IX_UserAuthorization_OrganizationId",
                table: "UserAuthorization");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "UserAuthorization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthorization",
                table: "UserAuthorization",
                columns: new[] { "UserId", "BUId", "CompanyId", "RoleId", "ProcessTypeId" });
        }
    }
}
