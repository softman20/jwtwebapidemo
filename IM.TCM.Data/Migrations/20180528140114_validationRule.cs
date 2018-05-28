using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class validationRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValidationRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountGroupId = table.Column<int>(nullable: false),
                    BUId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ProcessTypeId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationRule_AccountGroup_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidationRule_BusinessUnit_BUId",
                        column: x => x.BUId,
                        principalTable: "BusinessUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidationRule_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValidationRule_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValidationRuleUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ValidationRuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationRuleUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidationRuleUserRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidationRuleUserRole_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidationRuleUserRole_ValidationRule_ValidationRuleId",
                        column: x => x.ValidationRuleId,
                        principalTable: "ValidationRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_AccountGroupId",
                table: "ValidationRule",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_BUId",
                table: "ValidationRule",
                column: "BUId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_CompanyId",
                table: "ValidationRule",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_ProcessTypeId",
                table: "ValidationRule",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRuleUserRole_RoleId",
                table: "ValidationRuleUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRuleUserRole_UserId",
                table: "ValidationRuleUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRuleUserRole_ValidationRuleId",
                table: "ValidationRuleUserRole",
                column: "ValidationRuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationRuleUserRole");

            migrationBuilder.DropTable(
                name: "ValidationRule");
        }
    }
}
