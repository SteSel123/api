using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. -- Registration of the services 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Registers the OpenAPI services
builder.Services.AddControllers();// Registers the controllers
builder.Services.AddEndpointsApiExplorer();// Registers the API explorer for endpoint discovery voor de swaggerUi
builder.Services.AddDbContext<FridgeDbContext>(options =>
    options.UseInMemoryDatabase("FridgeDb")); // maakt de registratie van de DbContext. 


builder.Services.AddScoped<IFridgeRepository,FridgeRepository>();// Registers the FridgeRepository as the implementation of IFridgeRepository
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Because the DbContext is not like the controller Scoped automated when called on. We need to make change the code. 
//We have registred it in builder.Services.AddDbContext, now we need to create a scope (go to SeedDate.SeedFridgeData)

SeedData.SeedFridgeData(app.Services);

app.MapControllers();// Maps the controller endpoints
app.UseHttpsRedirection();// Redirects HTTP requests to HTTPS
Console.WriteLine(typeof(FridgeDbContext).FullName);
app.Run();// Runs the application

// MEANINFUL NAMES 
// SEPERATION OF CONCERN -> API - DB?
// Think about the classes if we have more items and also if we have commun items 
// don't name the class to the concept, think bigger
// upload fridge when done 
// next project: commit after every step: layer - scelethon - .. 