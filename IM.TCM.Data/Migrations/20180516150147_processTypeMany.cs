using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class processTypeMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ProcessType_ProcessTypeId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ProcessTypeId",
                table: "Company");

            migrationBuilder.CreateTable(
                name: "CompanyProcessType",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    ProcessTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProcessType", x => new { x.CompanyId, x.ProcessTypeId });
                    table.ForeignKey(
                        name: "FK_CompanyProcessType_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyProcessType_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProcessType_ProcessTypeId",
                table: "CompanyProcessType",
                column: "ProcessTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProcessType");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ProcessTypeId",
                table: "Company",
                column: "ProcessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ProcessType_ProcessTypeId",
                table: "Company",
                column: "ProcessTypeId",
                principalTable: "ProcessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
