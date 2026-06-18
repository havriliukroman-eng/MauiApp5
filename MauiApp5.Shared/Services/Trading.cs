namespace MauiApp5.Shared.Services
{
    public class TradingService : Itrading
    {
        public AppDbContext dbContext { get; set; }
        public TradingService(AppDbContext dbContext) { 
            this.dbContext = dbContext;
        } 
        public bool Trading(int UserId, decimal Value, int NewCurrencyId, int OldCurrencyId)
        {
            try
            { 

                var userWallet = dbContext.Wallets
                    .FirstOrDefault(x => x.UserId == UserId);
                var T = dbContext.Wallets.ToArray();
                if (userWallet == null)
                    return false;

                var userWalletUnit = dbContext.WalletUnits
                    .FirstOrDefault(x =>
                        x.WalletId == userWallet.Id &&
                        x.CurrencyId == OldCurrencyId);

                if (userWalletUnit == null)
                    return false;
                

                userWalletUnit.Value -= Value;

                var userWalletUnitTarget = (from WalletUnit in dbContext.WalletUnits
                                            where WalletUnit.WalletId == userWallet.Id && WalletUnit.CurrencyId == NewCurrencyId
                                            select WalletUnit).First();

                userWalletUnitTarget.Value += Convert(Value, NewCurrencyId, OldCurrencyId);
                dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        private decimal Convert(decimal value, int NewCurrencyId, int OldCurrencyId)
        {
            AppDbContext dbContext = new AppDbContext();

            var CurrencyRate = (from currencyRate in dbContext.CurrencyRates
                                where currencyRate.CurrencyTargetId == NewCurrencyId && currencyRate.CurrencySouseId == OldCurrencyId
                                select currencyRate).First();

            return value * (decimal)CurrencyRate.Value;
        }
    }
}
