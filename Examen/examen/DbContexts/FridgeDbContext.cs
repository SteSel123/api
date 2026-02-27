using System;
using examen.Model;
using Microsoft.EntityFrameworkCore;
namespace examen.DbContexts;

public class FridgeDbContext: DbContext
{
    public FridgeDbContext(DbContextOptions<FridgeDbContext> options):base(options)
    {
        
    }

    public DbSet<Item>Items{get;set;}
}
