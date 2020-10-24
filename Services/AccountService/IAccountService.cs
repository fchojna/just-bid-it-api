using System.Collections.Generic;
using System.Threading.Tasks;
using just_bid_it.Models;

namespace just_bid_it.Services.AccountService
{
    public interface IAccountService
    {
         Task<ServiceResponse<List<Account>>> GetAllAccounts();
         Task<ServiceResponse<Account>> GetAccountById(int id);
         Task<ServiceResponse<List<Account>>> AddAccount(Account newAccount);
    }
}