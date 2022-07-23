using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations.Goods
{
    public partial class AddImageIdGoods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DBImageIds",
                table: "Goods",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImageId",
                table: "Goods",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DBImageIds",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Goods");
        }
    }
}
