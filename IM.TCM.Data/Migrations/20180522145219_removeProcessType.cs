using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class removeProcessType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
