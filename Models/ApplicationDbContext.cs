using Microsoft.EntityFrameworkCore;

namespace StockAPI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base (options)
        {
            //ensure db is created
            Database.EnsureCreated();
        }

        public DbSet<Ticker> tickers { get; set; }

    }
}
