using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Data;

public static class SeedData
{
     public static void SeedFridgeData(IServiceProvider services)
    {
        // Create a scope (it is not a new one, because you request it from the ServiceProvider)
        using var scope = services.CreateScope();
        //Create an instance of FridgeDbContext in the scope (the scope was mentioned in Services.AddScoped<IFridgeRepository,FridgeRepository>())
        var context = scope.ServiceProvider.GetRequiredService<FridgeDbContext>();
        //Create Db if not created 
        context.Database.EnsureCreated();

        if (!context.Item.Any())
        {
            context.Item.Add(new Item
            {
                Id = Guid.NewGuid(),
                Name = "Kitchen Fridge",
                Quantity = 4,
                Category = Category.water,
                DateAdded = DateTime.Now,
                Note = "Contains milk and vegetables"
            });

            context.SaveChanges();
        }
    }
}

