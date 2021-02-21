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
    [Route("[controller]")]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IAuthenticationManager _auth;

        public AuctionController(IAuctionService auctionService, IAuthenticationManager auth)
        {
            _auctionService = auctionService;
            _auth = auth;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _auctionService.GetAllAuctions());
        }

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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCred)
        {
            var token = _auth.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok();
        }
    }
}