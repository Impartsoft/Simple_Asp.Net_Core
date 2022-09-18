using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations
{
    public partial class blogsandComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbBlog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Inputter = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    InputDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeleteTag = table.Column<int>(type: "integer", nullable: false),
                    Deleter = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBlog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbBlog_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbComment_tbBlog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "tbBlog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbComment_tbBlog_BlogId1",
                        column: x => x.BlogId1,
                        principalTable: "tbBlog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbComment_tbUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbBlog_UserId",
                table: "tbBlog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_BlogId",
                table: "tbComment",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_BlogId1",
                table: "tbComment",
                column: "BlogId1");

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_UserId",
                table: "tbComment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbComment");

            migrationBuilder.DropTable(
                name: "tbBlog");
        }
    }
}
