using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations
{
    public partial class commentPKchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComment_tbBlog_BlogId1",
                table: "tbComment");

            migrationBuilder.DropIndex(
                name: "IX_tbComment_BlogId1",
                table: "tbComment");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "tbComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlogId1",
                table: "tbComment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_BlogId1",
                table: "tbComment",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComment_tbBlog_BlogId1",
                table: "tbComment",
                column: "BlogId1",
                principalTable: "tbBlog",
                principalColumn: "Id");
        }
    }
}
