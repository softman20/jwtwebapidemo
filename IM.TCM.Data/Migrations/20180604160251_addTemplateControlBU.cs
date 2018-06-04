using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class addTemplateControlBU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BUId",
                table: "TemplateControl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTypeId",
                table: "TemplateControl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateControl_BUId",
                table: "TemplateControl",
                column: "BUId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateControl_ProcessTypeId",
                table: "TemplateControl",
                column: "ProcessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateControl_BusinessUnit_BUId",
                table: "TemplateControl",
                column: "BUId",
                principalTable: "BusinessUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateControl_ProcessType_ProcessTypeId",
                table: "TemplateControl",
                column: "ProcessTypeId",
                principalTable: "ProcessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateControl_BusinessUnit_BUId",
                table: "TemplateControl");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateControl_ProcessType_ProcessTypeId",
                table: "TemplateControl");

            migrationBuilder.DropIndex(
                name: "IX_TemplateControl_BUId",
                table: "TemplateControl");

            migrationBuilder.DropIndex(
                name: "IX_TemplateControl_ProcessTypeId",
                table: "TemplateControl");

            migrationBuilder.DropColumn(
                name: "BUId",
                table: "TemplateControl");

            migrationBuilder.DropColumn(
                name: "ProcessTypeId",
                table: "TemplateControl");
        }
    }
}
