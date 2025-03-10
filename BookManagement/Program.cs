using BookManagement.Application.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookManagement.Infrastructure.Repositories;

// Controller->Service->Repository->DbContext->Database

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CosmosDbContext>();

builder.Services.AddScoped<IBookRepository, CosmosBookRepository>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
