using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BankAPI.Data;
using BankAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<BankDataService>();
builder.Services.AddTransient<TransactionService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BankDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

