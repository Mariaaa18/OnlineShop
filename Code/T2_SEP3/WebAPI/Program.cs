using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using FileData;
using FileData.DAOs;
using Microsoft.AspNetCore.WebSockets;
using Shared.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<ISockCardDao, SockCardsFileDao>();
builder.Services.AddScoped<ISockCardLogic, SockCardLogic>();
builder.Services.AddScoped<IShoppingCartLogic, ShoppingCartLogic>();
builder.Services.AddScoped<IShoppingCartDao, ShoppingCartFileDao>();
builder.Services.AddScoped<ISocksInventoryDao, SocksInventoryFileDao>();
builder.Services.AddScoped<ISocksInventoryLogic, SocksInventoryLogic>();
builder.Services.AddScoped<ISocksLogic, SocksLogic>();
builder.Services.AddScoped<ISocksDao, SocksFileDao>();
builder.Services.AddScoped<ICardItemDao, CardItemFileDao>();
builder.Services.AddScoped<ICardItemLogic, CardItemLogic>();



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

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.Run();