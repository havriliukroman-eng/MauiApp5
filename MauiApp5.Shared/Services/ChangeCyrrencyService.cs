namespace MauiApp5.Shared.Services
{
    public class ChangeCyrrencyService : IChangeCurrency
    {
        public AppDbContext Context { get; set; }
        public ChangeCyrrencyService()
        {
            Context = new AppDbContext();
        }
        public bool ChangeRate(int SourseCurrencyId, int TargetCurrencyId, double Value)
        {
            try
            {
                var CurrencyRate = (from currencyRate in Context.CurrencyRates
                                    where currencyRate.CurrencyTargetId == SourseCurrencyId && currencyRate.CurrencySouseId == TargetCurrencyId
                                    select currencyRate).First();
                CurrencyRate.Value = Value;

                var CurrencyRateReturn = (from currencyRate in Context.CurrencyRates
                                          where currencyRate.CurrencyTargetId == TargetCurrencyId && currencyRate.CurrencySouseId == SourseCurrencyId
                                          select currencyRate).First();
                CurrencyRateReturn.Value = 1 / Value;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
