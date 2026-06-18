using MauiApp5;
using MauiApp5.Shared.Services;
using MauiApp5.Web.Components;
using MauiApp5.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the MauiApp5.Shared project
builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<IChangeCurrency, ChangeCyrrencyService>();
builder.Services.AddSingleton<Itrading, TradingService>();
builder.Services.AddSingleton<IUser, UserService>();
builder.Services.AddSingleton<ICurrency, CurrencyService>();
builder.Services.AddSingleton<IWallet, WalletService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(MauiApp5.Shared._Imports).Assembly);





app.Run();