public class ItemDto{ //TO DO: When do we need to create a DTO ? 
    public Guid Id{get;set;}
    public string? Note{get;set;}
    public int quantity
    {
        get;
        set
        {
            if(value>0)
             field = value;
            else
            throw new Exception("value must be > 1");
        }
    }
    public required string Name{get;set;}
    public Category category{get;set;}
}