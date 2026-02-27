using System;
using examen.DbContexts;
using examen.Mapping;
using examen.Model;

namespace examen.Services;

public class FridgeRepository : IfridgeRepository
{
    public readonly FridgeDbContext _dbContext;
    public FridgeRepository(FridgeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Item> GetItems()
    {
        var result = _dbContext.Items.ToList<Item>();
        return result;
    }

    public Item GetItemById(Guid id)
    {
         return _dbContext.Items.FirstOrDefault(x => x.Id == id);  
         //de x=>x.Id == id is een lambda 
         // het gaat naar een FirstOrDefault(Func<Item, bool> predicate)
    }

    public bool UpdateItem(Item item)
    {
        var existingItem = _dbContext.Items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem == null)
            return false; 

        FridgeMapping.ApplyMapping(existingItem, item);
        _dbContext.SaveChanges();
        return true;
    }

    public Item CreateItem(Item item)
    {
        Guid Id = new Guid();
        item.Id = Id;
        
        _dbContext.Items.Add(item);
        _dbContext.SaveChanges();

        return item; 
    }

    public bool DeleteItem(Guid id)
    {
         var item = _dbContext.Items.FirstOrDefault(x => x.Id == id);
         if(item == null)
            return false;
        
         _dbContext.Items.Remove(item);
         _dbContext.SaveChanges();
         return true;
    }
}
