using Microsoft.EntityFrameworkCore;

public class FridgeRepository:IFridgeRepository
{
    public FridgeDbContext _fridgeDbContext;
    public FridgeRepository(FridgeDbContext fridgeDbContext)
    {
        _fridgeDbContext = fridgeDbContext;
    }
    public async Task<IEnumerable<Item>> GetItems()
    {
        var result = await _fridgeDbContext.Item.ToListAsync();
        return result; 
    }

    public async Task<Item?> GetItemById(Guid guid)
    {
        var result = await _fridgeDbContext.Item.FirstOrDefaultAsync(x=>x.Id == guid);
        return result;
    } 

    public async Task<Item> CreateItem(Item item)
    {
        Guid guid = new Guid();
        item.Id = guid;
        _fridgeDbContext.Item.Add(item);
        return item;
    }

    public async Task<bool> UpdateItem(ItemDto ItemDto)
    {
        var result = await _fridgeDbContext.Item.FirstOrDefaultAsync(x=>x.Id == ItemDto.Id);
        if(result == null)
            return false; 
        
        FridgeMapper.ApplyUpdate(ItemDto,result);
        _fridgeDbContext.SaveChanges();
        return true; 
    }
}