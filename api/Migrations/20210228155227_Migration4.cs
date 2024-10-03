using Microsoft.EntityFrameworkCore.Migrations;

namespace just_bid_it.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalEquipment",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Generation",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccidentFree",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalEquipment",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "IsAccidentFree",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Auctions");
        }
    }
}
