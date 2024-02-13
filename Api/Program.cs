using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// adding entityframework.
builder.Services.AddDbContext<MoviesApiContext>(options =>
options.UseInMemoryDatabase("moviesDB"));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5005";  // idsvr4
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidateAudience = false };
    });


var app = builder.Build();
//var env = builder.Environment();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
