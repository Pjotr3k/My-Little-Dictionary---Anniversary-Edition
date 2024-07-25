using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    /// <inheritdoc />
    public partial class EntryRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryDefinitionAssociations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDefinitionAssociations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EntryDefinitionAssociations_Definition_DefinitionID",
                        column: x => x.DefinitionID,
                        principalTable: "Definition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryDefinitionAssociations_Entry_EntryID",
                        column: x => x.EntryID,
                        principalTable: "Entry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryDefinitionAssociations_DefinitionID",
                table: "EntryDefinitionAssociations",
                column: "DefinitionID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDefinitionAssociations_EntryID",
                table: "EntryDefinitionAssociations",
                column: "EntryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryDefinitionAssociations");
        }
    }
}
