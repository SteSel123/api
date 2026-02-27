using System;
using examen.DbContexts;

namespace examen.SeedData;

public static class SeedData
{
    public static void FridgeDatabase(WebApplication? webApplication)
    {
        using var scope = webApplication.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<FridgeDbContext>();

        if(!context.Items.Any())
        {
        context.Items.Add(new Model.Item{Name = "test"});
        context.SaveChanges();
        }        
    }
}
