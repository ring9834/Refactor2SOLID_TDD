namespace MyLibrary;

public class OrderProcessor
{
    public decimal CalculateTotal()
    {
        // Hard-coded dependency
        var db = new Database();
        var items = db.GetItems();
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.Price;
        }
        return total;
    }
}

public class Database
{
    public List<Item> GetItems()
    {
        // Simulate database call
        return new List<Item> { new Item { Price = 10.0m }, new Item { Price = 20.0m } };
    }
}

public class Item
{
    public decimal Price { get; set; }
}

