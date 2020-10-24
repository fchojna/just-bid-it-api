using System;

namespace just_bid_it.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public AccountType Type { get; set; } = 0;
    }
}