using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAPI.DBOperations;
using StockAPI.Models;
using System.Collections.Generic;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly ITicker _ticker;
        public TickerController(ITicker ticker)
        {
            _ticker = ticker;
        }
        [HttpGet]
        public async Task<IEnumerable<Ticker>> GetTickers()
        {
            return await _ticker.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Ticker>> GetTicker(int Id)
        {
            return await _ticker.Get(Id);   
        }

        [HttpPost]
        public async Task<ActionResult<Ticker>> PostTicker([FromBody] Ticker ticker)
        {
            var newTicker = await _ticker.Create(ticker);
            return CreatedAtAction(nameof(Ticker), new {Id = ticker.Id}, newTicker);  
        }

        [HttpPut]
         public async Task<ActionResult<Ticker>> PutTicker(int Id,[FromBody] Ticker ticker)
        {
            if(Id != ticker.Id)
            {
                return BadRequest();
            }
            
             await _ticker.Update(ticker);
            return NoContent();
            
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTicker(int Id)
        {
            var ticker = await _ticker.Get(Id);
            if (ticker == null)
                return NotFound();
             await _ticker.Delete(ticker.Id);
            return NoContent();
        }
    }
}
