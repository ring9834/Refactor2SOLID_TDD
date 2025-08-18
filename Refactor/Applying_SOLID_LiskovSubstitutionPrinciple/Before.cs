namespace MyLibrary;

// A base class Bird has a method Fly, but a derived class Ostrich cannot fly, leading to incorrect behavior when substituted.
// The Bird class assumes all birds can fly, which doesn’t reflect real-world domain knowledge (some birds, like ostriches, are flightless).
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying");
    }
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying high");
    }
}

// Ostrich inherits from Bird but throws an exception for Fly, breaking the expectation that any Bird can fly. This means Ostrich cannot be substituted 
// or Bird without altering the program’s behavior (causing exceptions).
public class Ostrich : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Ostriches cannot fly");
    }
}

// BirdWatcher assumes all Bird instances can fly, requiring type checks or try-catch blocks to handle Ostrich, which is a design flaw.
public class BirdWatcher
{
    public void MakeBirdFly(Bird bird)
    {
        bird.Fly(); // This will throw an exception for Ostrich
    }
}
