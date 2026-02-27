using System;
using examen.Model;

namespace examen.Mapping;

public static class FridgeMapping
{
    public static void ApplyMapping(Item existingItem, Item item)
    {
        existingItem.Id = item.Id;
        existingItem.Name = item.Name; 
        existingItem.Quantity = item.Quantity;
        existingItem.Note = item.Note;
        existingItem.category = item.category;
    }
}
