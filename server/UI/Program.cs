using DBAccess;
using DBAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using Services.ServicesApi;
using Services.ServicesImplementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configure the connection string
string connectionString = builder.Configuration.GetConnectionString("TaxiStationDB");

//Add services from DAL and BL layers
builder.Services.AddDALServices(connectionString);
builder.Services.AddServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDriverTemporaryLocationBlService, DriverTemporaryLocationBlService>();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(option =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    option.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();