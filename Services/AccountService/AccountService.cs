using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using just_bid_it.Data;
using just_bid_it.Models;
using Microsoft.EntityFrameworkCore;

namespace just_bid_it.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Account>>> AddAccount(Account newAccount)
        {
            var serviceResponse = new ServiceResponse<List<Account>>();
            await _context.Accounts.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Accounts.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Account>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<Account>();
            serviceResponse.Data = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Account>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<Account>>();
            serviceResponse.Data = await _context.Accounts.ToListAsync();
            return serviceResponse;
        }
    }
}