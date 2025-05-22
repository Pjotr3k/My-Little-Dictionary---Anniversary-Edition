using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    /// <inheritdoc />
    public partial class ICreatedModifiedToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById",
                table: "Project",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_CreatedById",
                table: "Project",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ModifiedById",
                table: "Project",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ModifiedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ModifiedById",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Project");
        }
    }
}
