﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class OtherEntities2111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "sellers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "sellers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
