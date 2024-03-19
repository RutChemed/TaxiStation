using DBAccess;
using DBAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.ServicesApi;
using Services.ServicesImplementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();
//this code takes conn string from app settings, BUT does not handle the problem of local path
builder.Services.AddDbContext<TaxiStationContext>((services, options) =>
{
    var config = services.GetRequiredService<IConfiguration>();
    var connString = config.GetConnectionString("TaxiStationDB");
    options.UseSqlServer(connString);
});
//DBActions db = new DBActions(builder.Configuration);
//string connStr = db.GetConnectionString("FactoryDB");
//builder.Services.AddDbContext<TaxiStationContext>(opt => opt.UseSqlServer(connStr));
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
