using System.ComponentModel.DataAnnotations;

namespace StockAPI.Models
{
    public class Ticker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TickerName { get; set; }

        [Required]
        public string StockName { get; set; }
    }
}
