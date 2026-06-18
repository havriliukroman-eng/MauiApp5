using System.ComponentModel.DataAnnotations;

namespace MauiApp5
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
