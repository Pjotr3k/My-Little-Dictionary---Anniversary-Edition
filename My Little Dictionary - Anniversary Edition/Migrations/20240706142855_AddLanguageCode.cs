using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Forms",
                table: "PartOfSpeech",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsLemma",
                table: "Form",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "IsLemma",
                table: "Form");

            migrationBuilder.AlterColumn<string>(
                name: "Forms",
                table: "PartOfSpeech",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
