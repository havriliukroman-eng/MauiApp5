using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp5.Shared.Services
{
    public interface IWallet 
    {
        public decimal GetUserWallet(int UserId, int CurrencyId);
    }
}
