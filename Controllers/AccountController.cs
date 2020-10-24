using System.Collections.Generic;
using System.Threading.Tasks;
using just_bid_it.Models;
using just_bid_it.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace just_bid_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

        [HttpPost]
        public async Task<IActionResult> AddAccount(Account newAccount)
        {
            return Ok(await _accountService.AddAccount(newAccount));
        }
    }
}