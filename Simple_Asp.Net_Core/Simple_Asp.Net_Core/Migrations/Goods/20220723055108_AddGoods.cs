using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations.Goods
{
    public partial class AddGoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
