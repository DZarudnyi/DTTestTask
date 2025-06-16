using Abstractions.IRepositories;
using Abstractions.IServices;
using Clients.Context;
using Clients.Mapper;
using Clients.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Person API",
        Version = "v1",
        Description = "API for managing persons and their addresses"
    });
});

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Register repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

// Register mappers
builder.Services.AddSingleton<PersonMapper>();
builder.Services.AddSingleton<AddressMapper>();

// Register services
builder.Services.AddScoped<IPersonService, PersonServiceImpl>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger();
app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API v1");
    ui.RoutePrefix = string.Empty;
});

app.UseAuthorization();
app.MapControllers();
app.Run();
