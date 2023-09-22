using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TableBallAPI;
using TableBallAPI.DatabaseContext;
using TableBallAPI.Interface;
using TableBallAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<TableBallContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("TableBallDb")));

// Register repositories for each model
builder.Services.AddScoped<IRepository<PlayerBaseModel>, Repository<PlayerBaseModel>>();
builder.Services.AddScoped<IRepository<BattleBaseModel>, Repository<BattleBaseModel>>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
