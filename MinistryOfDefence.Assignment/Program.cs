using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinistryOfDefence.Assignment.Extensions;
using MinistryOfDefence.Assignment.Models;
using MinistryOfDefence.Assignment.ServicesConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterDb(builder.Configuration);
builder.Services.RegisterService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

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
app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.Run();
