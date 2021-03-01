using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using just_bid_it.Data;
using just_bid_it.Dtos.Auction;
using just_bid_it.Models;
using Microsoft.EntityFrameworkCore;

namespace just_bid_it.Services.AuctionService
{
    public class AuctionService : IAuctionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuctionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Auction>>> AddAuction(AddAuctionDto newAuction)
        {
            var serviceResponse = new ServiceResponse<List<Auction>>();
            var auction = _mapper.Map<Auction>(newAuction);
            auction.FinalPrice = auction.StartPrice;
            auction.AuctionStart = DateTime.Now;
            await _context.Auctions.AddAsync(auction);
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