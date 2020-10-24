
using System;
using just_bid_it.Models;

namespace just_bid_it.Dtos.Account
{
    public class GetAccountDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public AccountType Type { get; set; }
    }
}