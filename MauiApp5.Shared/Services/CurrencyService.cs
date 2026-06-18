using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp5.Shared.Services
{
    public class CurrencyService : ICurrency
    {
        public AppDbContext Context { get; set; }
        public CurrencyService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public int GetCurrencyId(string CurrencyName)
        {
            return Context.Currencys
                     .FirstOrDefault(x => x.Name == CurrencyName ).CurrencyId;


        }
    }
}
