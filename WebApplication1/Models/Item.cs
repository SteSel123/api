public class Item
{
    public Guid Id {get;set;}
    public int Quantity
    {
        get;
        set
        {
            if(value > 0)
                field = value;
            else
                throw new FormatException("value of Quantity needs to be positive");
        }
    }
    public string? Note {get;set;}
    public required string Name {get;set;}
    public Category Category {get;set;}
    public DateTime DateAdded {get;set;}
}

public enum Category
{
    water, milks
}