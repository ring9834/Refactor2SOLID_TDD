namespace MyLibrary;

public abstract class Bird_After
{
    public string Name { get; }

    protected Bird_After(string name)
    {
        Name = name;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} makes a sound");
    }
}

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow_After : Bird_After, IFlyingBird
{
    public Sparrow_After() : base("Sparrow") { }

    public void Fly()
    {
        Console.WriteLine("Sparrow is flying high");
    }

    public override void MakeSound()
    {
        Console.WriteLine("Sparrow chirps");
    }
}

public class Ostrich_After : Bird_After
{
    public Ostrich_After() : base("Ostrich") { }

    public override void MakeSound()
    {
        Console.WriteLine("Ostrich booms");
    }
}

public class BirdWatcher_After
{
    public void MakeBirdFly(IFlyingBird bird)
    {
        bird.Fly(); // Only flying birds can be passed
    }

    public void ObserveBird(Bird_After bird)
    {
        bird.MakeSound(); // All birds can make a sound
    }
}
