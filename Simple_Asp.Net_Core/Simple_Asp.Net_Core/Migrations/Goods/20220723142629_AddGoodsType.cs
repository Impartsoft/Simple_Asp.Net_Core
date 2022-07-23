using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Asp.Net_Core.Migrations.Goods
{
    public partial class AddGoodsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Goods",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Goods");
        }
    }
}
