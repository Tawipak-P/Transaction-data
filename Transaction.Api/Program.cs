using Microsoft.EntityFrameworkCore;
using Transaction.Core.Services.Interfaces;
using Transaction.Core.Services;
using Transaction.Infrastructor;
using Serilog;
using Transaction.Infrastructor.Repositories;
using Transaction.Infrastructor.Repositories.Interfaces;

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




builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITempTransactionRepository, TempTransactionRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITempTransactionService, TempTransactionService>();



//Setup Serilog config
var serilogConfig = builder.Configuration.AddJsonFile("appsettings.json", reloadOnChange: true, optional: false).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(serilogConfig).CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
