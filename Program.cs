using BankCore.Data;
using BankCore.IdentityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using BankCore.Services;

var builder = WebApplication.CreateBuilder(args);
var Connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
    options.UseSqlServer(Connectionstring));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationIdentityDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

builder.Services.AddDbContext<VictorBankAppContext>(options => options.UseSqlServer(Connectionstring));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<DataInitializer>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<TransactionService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<DataInitializer>().SeedData();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
