using System.ComponentModel.DataAnnotations;

namespace MauiApp5.Shared.Services
{
    public class WalletUnit
    {
        public int WalletId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
