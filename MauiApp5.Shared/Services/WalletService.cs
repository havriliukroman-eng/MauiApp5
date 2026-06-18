using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp5.Shared.Services
{
    public class WalletService : IWallet
    {
        public AppDbContext Context { get; set; }
        public WalletService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public decimal GetUserWallet(int UserId, int CurrencyId)
        {
            
            var Wallet = Context.Wallets
               .Where(x => x.UserId == UserId);
            return Context.WalletUnits.Where(x => x.CurrencyId == CurrencyId && Wallet.Any(y => y.Id == x.WalletId)).FirstOrDefault().Value ;
        }
    }
}
