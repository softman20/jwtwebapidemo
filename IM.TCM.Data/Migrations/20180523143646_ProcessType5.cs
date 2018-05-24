using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IM.TCM.Data.Migrations
{
    public partial class ProcessType5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BusinessUnit");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BusinessUnit");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BusinessUnit");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BusinessUnit");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BusinessUnit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BusinessUnit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BusinessUnit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BusinessUnit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BusinessUnit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BusinessUnit",
                nullable: true);
        }
    }
}
