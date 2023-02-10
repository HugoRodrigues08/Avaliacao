using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escola.Data.Migrations
{
    public partial class primeira0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Curriculoq",
                table: "Professores",
                newName: "Linkedin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Linkedin",
                table: "Professores",
                newName: "Curriculoq");
        }
    }
}
