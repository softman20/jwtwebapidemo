using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class userAuhorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAuthorization",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BUId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    ProcessTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthorization", x => new { x.UserId, x.BUId, x.CompanyId, x.RoleId, x.ProcessTypeId });
                    table.ForeignKey(
                        name: "FK_UserAuthorization_BusinessUnit_BUId",
                        column: x => x.BUId,
                        principalTable: "BusinessUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAuthorization_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAuthorization_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAuthorization_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAuthorization_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_BUId",
                table: "UserAuthorization",
                column: "BUId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_CompanyId",
                table: "UserAuthorization",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_ProcessTypeId",
                table: "UserAuthorization",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorization_RoleId",
                table: "UserAuthorization",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAuthorization");
        }
    }
}
