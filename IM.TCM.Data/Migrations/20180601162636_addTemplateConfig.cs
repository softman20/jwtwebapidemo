using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class addTemplateConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Template",
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
                    table.PrimaryKey("PK_Template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Template_AccountGroup_AccountGroupId",
                        column: x => x.AccountGroupId,
                        principalTable: "AccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Template_BusinessUnit_BUId",
                        column: x => x.BUId,
                        principalTable: "BusinessUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Template_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Template_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateControlConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlterableApprover1 = table.Column<bool>(nullable: false),
                    AlterableApprover2 = table.Column<bool>(nullable: false),
                    AlterableApprover3 = table.Column<bool>(nullable: false),
                    AlterableProvider = table.Column<bool>(nullable: false),
                    Capital = table.Column<bool>(nullable: false),
                    DefaultValue = table.Column<string>(nullable: true),
                    Display = table.Column<bool>(nullable: false),
                    Mandatory = table.Column<bool>(nullable: false),
                    TemplateControlId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateControlConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateControlConfig_TemplateControl_TemplateControlId",
                        column: x => x.TemplateControlId,
                        principalTable: "TemplateControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateControlConfig_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Template_AccountGroupId",
                table: "Template",
                column: "AccountGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_BUId",
                table: "Template",
                column: "BUId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_CompanyId",
                table: "Template",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_ProcessTypeId",
                table: "Template",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateControlConfig_TemplateControlId",
                table: "TemplateControlConfig",
                column: "TemplateControlId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateControlConfig_TemplateId",
                table: "TemplateControlConfig",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateControlConfig");

            migrationBuilder.DropTable(
                name: "Template");
        }
    }
}
