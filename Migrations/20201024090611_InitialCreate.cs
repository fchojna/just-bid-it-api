using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace just_bid_it.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(nullable: false),
                    BuyerId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartPrice = table.Column<double>(nullable: false),
                    FinalPrice = table.Column<double>(nullable: false),
                    AuctionStart = table.Column<DateTime>(nullable: false),
                    AuctionFinish = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    ProductionCountry = table.Column<int>(nullable: false),
                    VinNumber = table.Column<string>(nullable: true),
                    EngineCapacity = table.Column<float>(nullable: false),
                    EnginePower = table.Column<float>(nullable: false),
                    Fuel = table.Column<int>(nullable: false),
                    Drive = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    HasParticleFilter = table.Column<bool>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    DoorCount = table.Column<int>(nullable: false),
                    SeatCount = table.Column<int>(nullable: false),
                    IsBroken = table.Column<bool>(nullable: false),
                    IsAccidentFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}
