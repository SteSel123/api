public static class FridgeMapper
{
    public static Item ApplyUpdate (ItemDto ItemDto, Item Item)
    { 
            Item.Name = ItemDto.Name;
            Item.Note = ItemDto.Note;
            Item.Quantity = ItemDto.quantity;
            Item.Category = ItemDto.category;  

            return Item;     
    }
}