using System.Collections.Generic;
using System.Threading.Tasks;
using just_bid_it.Dtos.Account;
using just_bid_it.Models;
using just_bid_it.Services.AccountService;
using just_bid_it_api.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace just_bid_it.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticationManager _auth;

        public AccountController(IAccountService accountService, IAuthenticationManager auth)
        {
            _accountService = accountService;
            _auth = auth;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _accountService.GetAllAccounts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _accountService.GetAccountById(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAccount(AddAccountDto newAccount)
        {
            return Ok(await _accountService.AddAccount(newAccount));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserCredentials userCred)
        {
            var validationResult = _accountService.ValidateLogin(userCred.Username, userCred.Password);
            if (!validationResult.Success) {
                return Unauthorized(validationResult.Message);
            }

            var token = _auth.GenerateToken(userCred.Username);
            return Ok(token);
        }
    }
}