using Microsoft.EntityFrameworkCore;

public class FridgeDbContext:DbContext
{
    public FridgeDbContext(DbContextOptions<FridgeDbContext> options):base(options)
    {
    }
    //connect with the in-memory db 
    public DbSet<Item>Item{get;set;} = null!;
}