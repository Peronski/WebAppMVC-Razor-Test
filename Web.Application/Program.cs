using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Test_Cinema.Models;
using Test_Cinema.Persisters;
using Test_Cinema.Retrievers;
using Test_Cinema.Utility;
using Web.Application.Data;

var builder = WebApplication.CreateBuilder(args);

//Using Tools package it's possible to create Tables in server directly by code using Migration:
// -Tools -> NuGet Packet Manager -> Console -> add-migration Add(ModelName)ToDatabase
//A new class will be created with options to create tables 


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

SqlConnection connection = new SqlConnection(builder.Configuration.GetConnectionString("DbConnectionString"));
SafeOperator safer = new SafeOperator();

builder.Services.AddSingleton(connection);
builder.Services.AddSingleton(safer);
builder.Services.AddSingleton<IRetriever<Film>, FilmRetriever>();
builder.Services.AddSingleton<IPersister<Film>, FilmPersister>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
