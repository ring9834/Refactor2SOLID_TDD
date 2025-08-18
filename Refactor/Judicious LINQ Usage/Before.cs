namespace MyLibrary;

public class Before6
{
    // Overusing LINQ
    public List<int> GetEvenNumbers(List<int> numbers)
    {
        return numbers.Where(n => n % 2 == 0).ToList();
    }
}
