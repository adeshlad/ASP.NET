using BookManagement.Application.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookManagement.Infrastructure.Repositories;

// Controller->Service->Repository->DbContext->Database

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
