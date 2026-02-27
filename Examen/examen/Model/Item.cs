using System;
using System.Data;

namespace examen.Model;

public class Item
{
    public Guid Id{get;set;}
    public required string Name {get;set;}
    public int Quantity {get;
        set
        {
            if (value>0) 
                field = value;
            else
                throw new DataException("value needs to be positive");
        }
    }
    public string? Note {get;set;}
    public Category category{get;set;}
}

public enum Category
{
    milk, water
}
