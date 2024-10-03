using AutoMapper;
using just_bid_it.Dtos.Account;
using just_bid_it.Dtos.Auction;
using just_bid_it.Models;

namespace just_bid_it
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, GetAccountDto>();
            CreateMap<AddAccountDto, Account>();
            
            CreateMap<Auction, GetAuctionListDto>();
            CreateMap<AddAuctionDto, Auction>();
        }
    }
}