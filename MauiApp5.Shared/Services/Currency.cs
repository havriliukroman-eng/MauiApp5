using System.ComponentModel.DataAnnotations;

namespace MauiApp5
{
    public class Currency
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
        [Key]
        public int CurrencyId { get; set; }
    
    } 

}
