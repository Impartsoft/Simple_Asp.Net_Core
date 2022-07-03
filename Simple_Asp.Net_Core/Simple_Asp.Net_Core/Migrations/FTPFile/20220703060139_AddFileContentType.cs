using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations.FTPFile
{
    public partial class AddFileContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileContentType",
                table: "FTPFiles",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContentType",
                table: "FTPFiles");
        }
    }
}
