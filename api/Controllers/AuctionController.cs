using System.Threading.Tasks;
using just_bid_it.Dtos.Auction;
using just_bid_it.Models;
using just_bid_it.Services.AuctionService;
using just_bid_it_api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace just_bid_it.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IAuthenticationManager _auth;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _auctionService.GetAllAuctions());
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _auctionService.GetAuctionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAuction(AddAuctionDto newAuction)
        {
            return Ok(await _auctionService.AddAuction(newAuction));
        }
    }
}