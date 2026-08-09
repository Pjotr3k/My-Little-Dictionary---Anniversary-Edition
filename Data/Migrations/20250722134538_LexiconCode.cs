using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    /// <inheritdoc />
    public partial class LexiconCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Project",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Dictionary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Code",
                table: "Project",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Project_Code",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Dictionary");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
