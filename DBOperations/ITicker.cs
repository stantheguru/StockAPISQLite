using StockAPI.Models;
using System.Collections.Generic;

namespace StockAPI.DBOperations
{
    public interface ITicker
    {

        //Retrieve all tickers
        Task<IEnumerable<Ticker>> Get();

        //Retrive a particular ticker
        Task<Ticker> Get(int Id);

        //Create ticker
        Task<Ticker> Create(Ticker ticker);

        //Update ticker
        Task Update(Ticker ticker);


        //Delete ticker
        Task Delete(int Id);

        
    }
}
