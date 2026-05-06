using DotNetEnv;
using Itransition_Project.Data;
using Itransition_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// var connectionString =
//     builder.Configuration.GetValue<string>("DB_CONNECTION_STRING")
//     ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.MapIdentityApi<User>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API is working");

app.MapGet("/admin", ()  => "Admin is working").RequireAuthorization();
app.MapGet("/user", () => "User is working");
app.Run();
