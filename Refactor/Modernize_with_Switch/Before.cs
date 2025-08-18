namespace MyLibrary;

public class Before8
{
    public string GetStatus(int code)
    {
        string status;
        if (code == 1)
            status = "Active";
        else if (code == 2)
            status = "Inactive";
        else
            status = "Unknown";
        return status;
    }
}
