using just_bid_it.Models;
using Microsoft.EntityFrameworkCore;

namespace just_bid_it.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}