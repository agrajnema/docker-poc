using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AuditLogTest.Migrations
{
    public partial class CustomerandAuditlogchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldAuditLog_AuditLogs_AuditLogId",
                table: "FieldAuditLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldAuditLog",
                table: "FieldAuditLog");

            migrationBuilder.RenameTable(
                name: "FieldAuditLog",
                newName: "FieldAuditLogs");

            migrationBuilder.RenameIndex(
                name: "IX_FieldAuditLog_AuditLogId",
                table: "FieldAuditLogs",
                newName: "IX_FieldAuditLogs_AuditLogId");

            migrationBuilder.AddColumn<string>(
                name: "ChangeLogs",
                table: "AuditLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "AuditLogs",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldAuditLogs",
                table: "FieldAuditLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldAuditLogs_AuditLogs_AuditLogId",
                table: "FieldAuditLogs",
                column: "AuditLogId",
                principalTable: "AuditLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldAuditLogs_AuditLogs_AuditLogId",
                table: "FieldAuditLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldAuditLogs",
                table: "FieldAuditLogs");

            migrationBuilder.DropColumn(
                name: "ChangeLogs",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "AuditLogs");

            migrationBuilder.RenameTable(
                name: "FieldAuditLogs",
                newName: "FieldAuditLog");

            migrationBuilder.RenameIndex(
                name: "IX_FieldAuditLogs_AuditLogId",
                table: "FieldAuditLog",
                newName: "IX_FieldAuditLog_AuditLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldAuditLog",
                table: "FieldAuditLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldAuditLog_AuditLogs_AuditLogId",
                table: "FieldAuditLog",
                column: "AuditLogId",
                principalTable: "AuditLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
