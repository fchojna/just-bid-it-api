using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using just_bid_it.Models;

namespace just_bid_it.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        List<Auction> auctions = new List<Auction>() 
        {
            new Auction()
            { 
                Id = 0,
                SellerId = 3,
                BuyerId = 4,
                Title = "Sprzedam Astre!",
                Location = "Katowice",
                StartPrice = 5000,
                FinalPrice = 0,
                AuctionStart = new DateTime(2020, 10, 20, 21, 0, 0),
                AuctionFinish = new DateTime(2020, 10, 20, 28, 0, 0),
                Type = BodyType.Estate,
                Brand = "Opel",
                Model = "Astra",
                ProductionYear = 2005,
                ProductionCountry = Country.Poland,
                VinNumber = "WP1AF2A23ELA47588",
                EngineCapacity = 1.6f,
                EnginePower = 180,
                Fuel = FuelType.Gasoline,
                Drive = DriveType.FrontWheelsDrive,
                Transmission = TransmissionType.Manual,
                HasParticleFilter = true,
                Color = Color.Black,
                DoorCount = 5,
                SeatCount = 5,
                IsBroken = false,
                IsAccidentFree = true
            }
        };

        public Task<ServiceResponse<List<Auction>>> AddAuction(Auction newAuction)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<Auction>>> GetAllAuctions()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<Auction>> GetAuctionById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}