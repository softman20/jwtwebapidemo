using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class ProcessType3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_ProcessTypeId",
                table: "UserAuthorization",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProcessType_ProcessTypeId",
                table: "CompanyProcessType",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroupProcessType_ProcessTypeId",
                table: "AccountGroupProcessType",
                column: "ProcessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGroupProcessType_ProcessType_ProcessTypeId",
                table: "AccountGroupProcessType",
                column: "ProcessTypeId",
                principalTable: "ProcessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProcessType_ProcessType_ProcessTypeId",
                table: "CompanyProcessType",
                column: "ProcessTypeId",
                principalTable: "ProcessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthorization_ProcessType_ProcessTypeId",
                table: "UserAuthorization",
                column: "ProcessTypeId",
                principalTable: "ProcessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGroupProcessType_ProcessType_ProcessTypeId",
                table: "AccountGroupProcessType");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProcessType_ProcessType_ProcessTypeId",
                table: "CompanyProcessType");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthorization_ProcessType_ProcessTypeId",
                table: "UserAuthorization");

            migrationBuilder.DropTable(
                name: "ProcessType");

            migrationBuilder.DropIndex(
                name: "IX_UserAuthorization_ProcessTypeId",
                table: "UserAuthorization");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProcessType_ProcessTypeId",
                table: "CompanyProcessType");

            migrationBuilder.DropIndex(
                name: "IX_AccountGroupProcessType_ProcessTypeId",
                table: "AccountGroupProcessType");
        }
    }
}
