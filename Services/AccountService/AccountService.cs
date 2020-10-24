using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using just_bid_it.Models;

namespace just_bid_it.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private List<Account> accounts = new List<Account>()
        {
            new Account() { Id=0, FullName="Filip Chojna", Nickname="Dante", Email="filipchojna@test.com", 
                            Password="Filip123#", CreateDate = new System.DateTime(2020, 10, 15, 18, 0, 0), Type=AccountType.Administrator },

            new Account() { Id=1, FullName="Jan Kowalski", Nickname="MrKowalsky", Email="jan.kowalski@test.com", 
                            Password="Jan123#", CreateDate = new System.DateTime(2020, 10, 16, 8, 30, 0), Type=AccountType.Moderator },
            
            new Account() { Id=2, FullName="Anna Nowak", Nickname="Anka1984", Email="anna.nowak@test.com", 
                            Password="Anna123#", CreateDate = new System.DateTime(2020, 10, 16, 14, 17, 0) },
            
            new Account() { Id=3, FullName="Andrzej Nieważne", Nickname="GalAnonim", Email="andrzej.niewazne@test.com", 
                            Password="Andrzej123#", CreateDate = new System.DateTime(2020, 10, 16, 16, 58, 0) },
            
            new Account() { Id=4, FullName="Monika Kowalska", Nickname="ŻonkaModeratora", Email="monika.kowalska@test.com", 
                            Password="Monika123#", CreateDate = new System.DateTime(2020, 10, 17, 22, 39, 0) }
        };

        public async Task<ServiceResponse<List<Account>>> AddAccount(Account newAccount)
        {
            var serviceResponse = new ServiceResponse<List<Account>>();
            accounts.Add(newAccount);
            serviceResponse.Data = accounts;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Account>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<Account>();
            serviceResponse.Data = accounts.FirstOrDefault(a => a.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Account>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<Account>>();
            serviceResponse.Data = accounts;
            return serviceResponse;
        }
    }
}