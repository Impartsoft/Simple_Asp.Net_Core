using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCommand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HowTo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Line = table.Column<string>(type: "text", nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCommand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFTPFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FileContentType = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FTPFileName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FTPPath = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFTPFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbGood",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MainImageId = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DBImageIds = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Inputter = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    InputDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleteTag = table.Column<int>(type: "integer", nullable: false),
                    Deleter = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbGood", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCommand");

            migrationBuilder.DropTable(
                name: "tbFTPFile");

            migrationBuilder.DropTable(
                name: "tbGood");
        }
    }
}
