namespace MyLibrary;

public class After6
{
    // Replaced LINQ with a foreach loop to reduce overhead for large collections.
    // Pre-allocated List capacity to minimize resizing.
    // numbers.Count / 2 is saying: “I expect result to hold roughly half as many items as numbers.”
    // This is not the number of elements actually in the list — it’s the size of the internal array that the list allocates at the start.
    public List<int> GetEvenNumbers(List<int> numbers)
    {
        var result = new List<int>(numbers.Count / 2);
        foreach (var n in numbers)
        {
            if (n % 2 == 0)
            {
                result.Add(n);
            }
        }
        return result;
    }
}
