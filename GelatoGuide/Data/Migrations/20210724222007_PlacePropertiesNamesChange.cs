using Microsoft.EntityFrameworkCore.Migrations;

namespace GelatoGuide.Data.Migrations
{
    public partial class PlacePropertiesNamesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Twitter",
                table: "Places",
                newName: "TwitterUrl");

            migrationBuilder.RenameColumn(
                name: "TakeawayLink",
                table: "Places",
                newName: "TakeawayUrl");

            migrationBuilder.RenameColumn(
                name: "InstagramLink",
                table: "Places",
                newName: "InstagramUrl");

            migrationBuilder.RenameColumn(
                name: "FoodpandaLink",
                table: "Places",
                newName: "FoodpandaUrl");

            migrationBuilder.RenameColumn(
                name: "FacebookLink",
                table: "Places",
                newName: "FacebookUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwitterUrl",
                table: "Places",
                newName: "Twitter");

            migrationBuilder.RenameColumn(
                name: "TakeawayUrl",
                table: "Places",
                newName: "TakeawayLink");

            migrationBuilder.RenameColumn(
                name: "InstagramUrl",
                table: "Places",
                newName: "InstagramLink");

            migrationBuilder.RenameColumn(
                name: "FoodpandaUrl",
                table: "Places",
                newName: "FoodpandaLink");

            migrationBuilder.RenameColumn(
                name: "FacebookUrl",
                table: "Places",
                newName: "FacebookLink");
        }
    }
}
