using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations
{
    public partial class userTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_tbUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbUser");
        }
    }
}
