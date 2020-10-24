using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using just_bid_it.Data;
using just_bid_it.Models;
using Microsoft.EntityFrameworkCore;

namespace just_bid_it.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        private readonly DataContext _context;

        public AuctionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Auction>>> AddAuction(Auction newAuction)
        {
            var serviceResponse = new ServiceResponse<List<Auction>>();
            await _context.Auctions.AddAsync(newAuction);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Auctions.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Auction>>> GetAllAuctions()
        {
            var serviceResponse = new ServiceResponse<List<Auction>>();
            serviceResponse.Data = await _context.Auctions.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Auction>> GetAuctionById(int id)
        {
            var serviceResponse = new ServiceResponse<Auction>();
            serviceResponse.Data = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);
            return serviceResponse;
        }
    }
}