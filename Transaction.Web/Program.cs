using Transaction.Infrastructor;
using Microsoft.EntityFrameworkCore;
using Transaction.Infrastructor.Repositories.Interfaces;
using Transaction.Infrastructor.Repositories;
using Serilog;
using Transaction.Web.MappingConfig;
using Transaction.Web.Services.Interfaces;
using Transaction.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TransactionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransactionDb"));
});
builder.Services.AddDbContext<TempTransactionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Temp_TransactionDb"));
});


builder.Services.AddHttpClient<IBaseService, BaseService>();
builder.Services.AddHttpClient<ITransactionService, TransactionService>();
builder.Services.AddHttpClient<ITempTransactionService, TempTransactionService>();


//builder.Services.AddScoped<ITempTransactionRepository, TempTransactionRepository>();
//builder.Services.AddScoped<ITempTransactionService, TempTransactionService>();


builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITempTransactionService, TempTransactionService>();



builder.Services.AddAutoMapper(typeof(MappingConfig));

//Setup Serilog config
var serilogConfig = builder.Configuration.AddJsonFile("appsettings.json", reloadOnChange: true, optional: false).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(serilogConfig).CreateLogger();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
