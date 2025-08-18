namespace MyLibrary;

// Used switch expression for concise, functional-style code.
public class After8
{
    public string GetStatus(int code) => code switch
    {
        1 => "Active",
        2 => "Inactive",
        _ => "Unknown"
    };
}
