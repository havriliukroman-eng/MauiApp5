namespace MauiApp5.Shared.Services
{
    public interface IChangeCurrency
    {
        public bool ChangeRate(int SourseCurrencyId, int TargetCurrencyId, double Value);
    }
}
