using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    /// <inheritdoc />
    public partial class NamesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOfSpeech_Project_LanguageID",
                table: "PartOfSpeech");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Lexeme_EntryID",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Forms",
                table: "PartOfSpeech");

            migrationBuilder.RenameColumn(
                name: "EntryID",
                table: "Word",
                newName: "LexemeID");

            migrationBuilder.RenameIndex(
                name: "IX_Word_EntryID",
                table: "Word",
                newName: "IX_Word_LexemeID");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "PartOfSpeech",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_PartOfSpeech_LanguageID",
                table: "PartOfSpeech",
                newName: "IX_PartOfSpeech_ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfSpeech_Project_ProjectID",
                table: "PartOfSpeech",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Lexeme_LexemeID",
                table: "Word",
                column: "LexemeID",
                principalTable: "Lexeme",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOfSpeech_Project_ProjectID",
                table: "PartOfSpeech");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_Lexeme_LexemeID",
                table: "Word");

            migrationBuilder.RenameColumn(
                name: "LexemeID",
                table: "Word",
                newName: "EntryID");

            migrationBuilder.RenameIndex(
                name: "IX_Word_LexemeID",
                table: "Word",
                newName: "IX_Word_EntryID");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "PartOfSpeech",
                newName: "LanguageID");

            migrationBuilder.RenameIndex(
                name: "IX_PartOfSpeech_ProjectID",
                table: "PartOfSpeech",
                newName: "IX_PartOfSpeech_LanguageID");

            migrationBuilder.AddColumn<string>(
                name: "Forms",
                table: "PartOfSpeech",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfSpeech_Project_LanguageID",
                table: "PartOfSpeech",
                column: "LanguageID",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Lexeme_EntryID",
                table: "Word",
                column: "EntryID",
                principalTable: "Lexeme",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
