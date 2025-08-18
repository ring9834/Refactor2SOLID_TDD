namespace MyLibrary;

public class Before1
{
    public double Calc(int a, int b, string t)
    {
        double r = 0;
        if (t == "add")
        {
            r = a + b;
        }
        else if (t == "sub")
        {
            r = a - b;
        }
        else if (t == "mul")
        {
            r = a * b;
        }
        return r;
    }
}
