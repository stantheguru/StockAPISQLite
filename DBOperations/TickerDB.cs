using Microsoft.EntityFrameworkCore;
using StockAPI.Models;

namespace StockAPI.DBOperations
{
    public class TickerDB : ITicker
    {
        private readonly ApplicationDbContext _context;

        public TickerDB(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticker> Create(Ticker ticker)
        {
            _context.tickers.Add(ticker);
            await _context.SaveChangesAsync();  
            return ticker;
        }

        public async Task Delete(int Id)
        {
            var ticker = await _context.tickers.FindAsync(Id);
            //Remove
            _context.tickers.Remove(ticker);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticker>> Get()
        {
            var tickerList = await _context.tickers.ToListAsync();
            return tickerList;
        }

        public async Task<Ticker> Get(int Id)
        {
            var ticker = await _context.tickers.FindAsync(Id);
            return ticker;
        }

        public async Task Update(Ticker ticker)
        {
            _context.Entry(ticker).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
