using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations.FTPFile
{
    public partial class AddReName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FTPFileName",
                table: "FTPFiles",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FTPPath",
                table: "FTPFiles",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FTPFiles",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FTPFileName",
                table: "FTPFiles");

            migrationBuilder.DropColumn(
                name: "FTPPath",
                table: "FTPFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FTPFiles");
        }
    }
}
