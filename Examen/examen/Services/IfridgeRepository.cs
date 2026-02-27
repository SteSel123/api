using System;
using System.Collections;
using examen.Model;

namespace examen.Services;

public interface IfridgeRepository
{
    public IEnumerable<Item> GetItems();
    public Item GetItemById(Guid id);
    public Item CreateItem(Item item);
    public bool UpdateItem(Item item);
    public bool DeleteItem(Guid Id);
}
