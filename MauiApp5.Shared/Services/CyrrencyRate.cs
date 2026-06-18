using System.ComponentModel.DataAnnotations;

namespace MauiApp5.Shared.Services
{
    public class CurrencyRate
    {
        [Key]
        public int CurrencyRateId { get; set; }
        public int CurrencyTargetId { get; set; }
        public int CurrencySouseId { get; set; }
        public double Value { get; set; }
    }
}