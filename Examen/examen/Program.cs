using examen.DbContexts;
using examen.SeedData;
using examen.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IfridgeRepository,FridgeRepository>();// moet je toevoegen 
// is addScoped omdat ASP.Net de repos niet kent. 
builder.Services.AddDbContext<Fridge2DbContext>(options =>
    options.UseInMemoryDatabase("FridgeDb"));

    
var app = builder.Build();
SeedData.FridgeDatabase(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
