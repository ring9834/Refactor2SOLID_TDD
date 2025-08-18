using System.Text;

namespace MyLibrary;

public class After5
{
    // Replaced string concatenation with StringBuilder for better memory and performance.
    // Handled edge case (empty list) explicitly.
    public string BuildReport(List<string> items)
    {
        var builder = new StringBuilder();
        foreach (var item in items)
        {
            builder.Append(item).Append(", ");
        }
        if (builder.Length > 0)
        {
            builder.Length -= 2; // Remove trailing ", "
        }
        return builder.ToString();
    }
}
