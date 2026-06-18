namespace MauiApp5.Shared.Services
{
    public interface Itrading
    {
        public bool Trading(int UserId, decimal Value, int NewCurrencyId, int OldCurrencyId);
    }
}
