using UI.ApiController;
using UI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Configure the connection string
string connectionString = builder.Configuration.GetConnectionString("TaxiStationDB");

//Add services from DAL layers
builder.Services.AddRepositories(connectionString);

//Add services from BL layers
builder.Services.AddServices();

builder.Services.AddScoped<IPhysicalEmployeeDetailController, PhysicalEmployeeDetailController>();
builder.Services.AddScoped<ITechnicalEmployeeDetailController, TechnicalEmployeeDetailController>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(option =>
{
    //var frontendURL = configuration.GetValue<string>("frontend_url");
    var frontendURL = builder.Configuration.GetValue<string>("frontend_url");
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