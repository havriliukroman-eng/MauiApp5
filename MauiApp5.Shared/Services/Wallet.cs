using System.ComponentModel.DataAnnotations;

namespace MauiApp5
{
    public class Wallet
    {
        public int UserId { get; set; }
        [Key]
        public int Id { get; set; }
    }

}
