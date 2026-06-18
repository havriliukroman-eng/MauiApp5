using MauiApp5.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace MauiApp5
{
    public class AppDbContext : DbContext
    {
        private static bool IsCreated {  get; set; } = false;
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletUnit> WalletUnits { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public AppDbContext()
        {
            if (!IsCreated && false) {
                IsCreated = true;
                Database.EnsureCreated();
                var dollar = Currencys.Add(new Currency { Name = "dollar", CountryName = "USA", CurrencyId = 0 });
                var euro = Currencys.Add(new Currency { Name = "euro", CountryName = "Europe", CurrencyId = 1 });
                var grivna = Currencys.Add(new Currency { Name = "grivna", CountryName = "Ukraine", CurrencyId = 2 });
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = euro.Entity.CurrencyId, CurrencySouseId = dollar.Entity.CurrencyId, Value = 0.85, CurrencyRateId = 1});
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = dollar.Entity.CurrencyId, CurrencySouseId = grivna.Entity.CurrencyId, Value = 0.022, CurrencyRateId =2 });
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = grivna.Entity.CurrencyId, CurrencySouseId = dollar.Entity.CurrencyId, Value = 47, CurrencyRateId =3});
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = euro.Entity.CurrencyId, CurrencySouseId = grivna.Entity.CurrencyId, Value = 0.22, CurrencyRateId =4});
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = grivna.Entity.CurrencyId, CurrencySouseId = euro.Entity.CurrencyId, Value = 49, CurrencyRateId =5});
                CurrencyRates.Add(new CurrencyRate { CurrencyTargetId = dollar.Entity.CurrencyId, CurrencySouseId = euro.Entity.CurrencyId, Value = 1.17, CurrencyRateId = 6 });
                var user = Users.Add(new User { name = "Roman", id =1});
                var wallet = Wallets.Add(new Wallet { UserId = user.Entity.id, Id =1 });

                WalletUnits.Add(new WalletUnit { WalletId = wallet.Entity.Id, Value = 100, CurrencyId = dollar.Entity.CurrencyId, Id =1});
                WalletUnits.Add(new WalletUnit { WalletId = wallet.Entity.Id, Value = 1000, CurrencyId = grivna.Entity.CurrencyId, Id =2});
                SaveChanges();
            }
           /* else { Database.EnsureDeleted(); } */
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestDb9;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurrencyRate>()
                .Property(x => x.CurrencyRateId)
                .ValueGeneratedNever();
            modelBuilder.Entity<Currency>()
              .Property(x => x.CurrencyId)
              .ValueGeneratedNever();
            modelBuilder.Entity<User>()
              .Property(x => x.id)
              .ValueGeneratedNever();
            modelBuilder.Entity<WalletUnit>()
              .Property(x => x.Id)
              .ValueGeneratedNever();
            modelBuilder.Entity<Wallet>()
              .Property(x => x.Id)
              .ValueGeneratedNever();
        }

    }
}