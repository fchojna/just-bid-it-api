using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using just_bid_it.Data;
using just_bid_it.Models;
using Microsoft.EntityFrameworkCore;
using just_bid_it.Dtos.Account;
using System;

namespace just_bid_it.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AccountService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> AddAccount(AddAccountDto newAccount)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            var account = _mapper.Map<Account>(newAccount);
            account.CreateDate = DateTime.Now;
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Accounts.Select(a => _mapper.Map<GetAccountDto>(a)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Account>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<Account>();
            serviceResponse.Data = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            serviceResponse.Data = await _context.Accounts.Select(a => _mapper.Map<GetAccountDto>(a)).ToListAsync();
            return serviceResponse;
        }

        public ServiceResponse<string> ValidateLogin(string username, string password)
        {
            var serviceResponse = new ServiceResponse<string>();
            serviceResponse.Success = _context.Accounts.Any(a => a.Nickname==username && a.Password==password);
            if (!serviceResponse.Success) {
                serviceResponse.Message = _context.Accounts.Any(a => a.Nickname==username) ? "Invalid password!" : "User not found!";
            }
            serviceResponse.Data = username;
            return serviceResponse;
        }
    }
}