namespace MyLibrary;

// Injectable dependency
public class OrderProcessor_After
{
    private readonly IDatabase _database;

    public OrderProcessor_After(IDatabase database)
    {
        _database = database;
    }

    public decimal CalculateTotal()
    {
        var items = _database.GetItems();
        return items.Sum(item => item.Price);
    }
}

public interface IDatabase
{
    IEnumerable<Item> GetItems();
}
