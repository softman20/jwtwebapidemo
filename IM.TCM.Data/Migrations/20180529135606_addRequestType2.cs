using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class addRequestType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "ValidationRule",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule");

            migrationBuilder.AlterColumn<int>(
                name: "RequestTypeId",
                table: "ValidationRule",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ValidationRule_RequestType_RequestTypeId",
                table: "ValidationRule",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
