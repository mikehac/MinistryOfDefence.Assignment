using Microsoft.EntityFrameworkCore;
using MinistryOfDefence.Assignment.Extensions;
using MinistryOfDefence.Assignment.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionString:ShoppingDb"]);
    });

builder.Services.RegisterService();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
