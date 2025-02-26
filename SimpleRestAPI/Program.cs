using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SimpleRestAPI.Data;
using SimpleRestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SchoolsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Configuration for Mapster
TypeAdapterConfig<SchoolDTO, School>.NewConfig()
    .Ignore(dest => dest.Id);  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
