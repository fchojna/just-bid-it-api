using System.Collections.Generic;
using System.Threading.Tasks;
using just_bid_it.Dtos.Auction;
using just_bid_it.Models;

namespace just_bid_it.Services.AuctionService
{
    public interface IAuctionService
    {
         Task<ServiceResponse<List<GetAuctionListDto>>> GetAllAuctions();
         Task<ServiceResponse<Auction>> GetAuctionById(int id);
         Task<ServiceResponse<List<GetAuctionListDto>>> AddAuction(AddAuctionDto newAuction);
    }
}