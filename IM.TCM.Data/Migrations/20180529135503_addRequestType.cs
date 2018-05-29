using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class addRequestType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "ValidationRule",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_RequestTypeId",
                table: "ValidationRule",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropIndex(
                name: "IX_ValidationRule_RequestTypeId",
                table: "ValidationRule");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "ValidationRule");
        }
    }
}
