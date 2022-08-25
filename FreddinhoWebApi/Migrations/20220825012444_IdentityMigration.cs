﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreddinhoWebApi.Migrations
{
    public partial class IdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    CellphoneNumber = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ACCOUNT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_DEPENDENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    BirthYear = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AccountModelId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DEPENDENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_DEPENDENT_T_ACCOUNT_AccountModelId",
                        column: x => x.AccountModelId,
                        principalTable: "T_ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_DEPENDENT_AccountModelId",
                table: "T_DEPENDENT",
                column: "AccountModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_DEPENDENT");

            migrationBuilder.DropTable(
                name: "T_ACCOUNT");
        }
    }
}
