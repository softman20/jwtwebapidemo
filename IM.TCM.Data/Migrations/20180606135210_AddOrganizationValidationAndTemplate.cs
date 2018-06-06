using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class AddOrganizationValidationAndTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "ValidationRule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Template",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_OrganizationId",
                table: "ValidationRule",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_OrganizationId",
                table: "Template",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Template_SalesOrganization_OrganizationId",
                table: "Template",
                column: "OrganizationId",
                principalTable: "SalesOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationRule_SalesOrganization_OrganizationId",
                table: "ValidationRule",
                column: "OrganizationId",
                principalTable: "SalesOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Template_SalesOrganization_OrganizationId",
                table: "Template");

            migrationBuilder.DropForeignKey(
                name: "FK_ValidationRule_SalesOrganization_OrganizationId",
                table: "ValidationRule");

            migrationBuilder.DropIndex(
                name: "IX_ValidationRule_OrganizationId",
                table: "ValidationRule");

            migrationBuilder.DropIndex(
                name: "IX_Template_OrganizationId",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "ValidationRule");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Template");
        }
    }
}
