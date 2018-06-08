using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class addControlMasterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlTypeId",
                table: "TemplateControlConfig",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ControlMasterData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BUId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProcessTypeId = table.Column<int>(nullable: false),
                    TemplateControlId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlMasterData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlMasterData_BusinessUnit_BUId",
                        column: x => x.BUId,
                        principalTable: "BusinessUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlMasterData_ProcessType_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "ProcessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlMasterData_TemplateControl_TemplateControlId",
                        column: x => x.TemplateControlId,
                        principalTable: "TemplateControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateControlConfig_ControlTypeId",
                table: "TemplateControlConfig",
                column: "ControlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMasterData_BUId",
                table: "ControlMasterData",
                column: "BUId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMasterData_ProcessTypeId",
                table: "ControlMasterData",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMasterData_TemplateControlId",
                table: "ControlMasterData",
                column: "TemplateControlId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateControlConfig_ControlType_ControlTypeId",
                table: "TemplateControlConfig",
                column: "ControlTypeId",
                principalTable: "ControlType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateControlConfig_ControlType_ControlTypeId",
                table: "TemplateControlConfig");

            migrationBuilder.DropTable(
                name: "ControlMasterData");

            migrationBuilder.DropTable(
                name: "ControlType");

            migrationBuilder.DropIndex(
                name: "IX_TemplateControlConfig_ControlTypeId",
                table: "TemplateControlConfig");

            migrationBuilder.DropColumn(
                name: "ControlTypeId",
                table: "TemplateControlConfig");
        }
    }
}
