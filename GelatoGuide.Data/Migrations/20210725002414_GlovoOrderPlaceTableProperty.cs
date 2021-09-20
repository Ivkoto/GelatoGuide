using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoGuide.Data.Migrations
{
    public partial class GlovoOrderPlaceTableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GlovoUrl",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GlovoUrl",
                table: "Places");
        }
    }
}
