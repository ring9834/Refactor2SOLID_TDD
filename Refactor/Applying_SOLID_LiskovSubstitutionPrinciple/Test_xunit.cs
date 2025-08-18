using Xunit;
namespace MyLibrary;

public class BirdTests
{
    [Fact]
    public void Sparrow_CanFly()
    {
        // Arrange
        var sparrow = new Sparrow_After();
        var watcher = new BirdWatcher_After();

        // Act
        watcher.MakeBirdFly(sparrow);

        // Assert (No exception, output is correct)
        // In a real test, you might capture console output
    }

    [Fact]
    public void Ostrich_CannotBePassedToFly()
    {
        // Arrange
        var ostrich = new Ostrich_After();
        var watcher = new BirdWatcher_After();

        // Act
        watcher.ObserveBird(ostrich); // Works fine

        // Assert: Cannot call MakeBirdFly(ostrich) because Ostrich does not implement IFlyingBird
        // This is enforced at compile time, preventing runtime errors
    }

    [Fact]
    public void Sparrow_MakesSound()
    {
        // Arrange
        var sparrow = new Sparrow_After();
        var watcher = new BirdWatcher_After();

        // Act
        watcher.ObserveBird(sparrow);

        // Assert (No exception, output is correct)
    }
}
