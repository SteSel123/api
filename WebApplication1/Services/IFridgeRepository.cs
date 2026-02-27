public interface IFridgeRepository
{
    public Task<IEnumerable<Item>> GetItems();
    public Task<Item?> GetItemById(Guid guid);
    public Task<Item> CreateItem(Item item);
    public Task<bool> UpdateItem(ItemDto item3Dto);
}