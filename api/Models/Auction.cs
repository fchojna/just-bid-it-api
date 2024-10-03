using System;

namespace just_bid_it.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public double StartPrice { get; set; }
        public double FinalPrice { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionFinish { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string ProductionCountry { get; set; }
        public string VinNumber { get; set; }
        public int EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public string Fuel { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public int HasParticleFilter { get; set; }
        public string Color { get; set; }
        public int DoorCount { get; set; }
        public int SeatCount { get; set; }
        public int IsBroken { get; set; }
        public string Generation { get; set; }
        public int Mileage { get; set; }
        public int IsAccidentFree { get; set; }
        public string AdditionalEquipment { get; set; }
    }
}