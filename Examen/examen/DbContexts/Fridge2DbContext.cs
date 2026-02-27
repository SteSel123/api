using System;
using examen.Model;
using Microsoft.EntityFrameworkCore;

namespace examen.DbContexts;

public class Fridge2DbContext:DbContext
{
    public Fridge2DbContext(DbContextOptions<FridgeDbContext> options): base(options)
    {
        
    }

    public DbSet<Item>Items {get;set;}
}
