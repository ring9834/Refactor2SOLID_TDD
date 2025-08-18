namespace MyLibrary;

public class Before5
{
    // Inefficient string concatenation in a loop
    public string BuildReport(List<string> items)
    {
        string report = "";
        foreach (var item in items)
        {
            report += item + ", ";
        }
        return report.TrimEnd(',', ' ');
    }
}
