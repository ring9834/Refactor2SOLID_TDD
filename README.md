# Refactor & UnitTest to SOLID Principles

## Example - Test EventHandler
```sh
    public class Stock
    {
        public event EventHandler<int>? StockLevelChanged;

        private int _stockLevel;
        public void UpdateStock(int newLevel)
        {
            _stockLevel = newLevel;
            StockLevelChanged?.Invoke(this, _stockLevel);
        }
    }
```

```sh
    public class EventHandlerTests
    {
        [Fact]
        public void UpdateStock_ValidLevel_RaisesStockLevelChangedEvent()
        {
            // Arrange
            var stock = new Stock();
            int receivedLevel = 0;
            stock.StockLevelChanged += (sender, level) => receivedLevel = level;

            // Act
            stock.UpdateStock(100);

            // Assert
            Assert.Equal(100, receivedLevel);
        }
    }
```

## Example - Test SinglR
```sh
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
```

```sh
    public class SignalRTests
    {
        // _mockClients: A Mock<IHubCallerClients> object, representing a mock of the SignalR interface that provides access to connected clients.
        // Creates a mock of the IHubCallerClients interface, which SignalR uses to manage client connections (sending messages to all clients, a group, or a specific client).
        private readonly Mock<IHubCallerClients> _mockClients;
        // _mockClientProxy: A Mock<IClientProxy> object, representing a mock of the SignalR interface for interacting with a group of clients (sending messages to them).
        // Creates a mock of the IClientProxy interface, which represents a proxy for sending messages to clients.
        private readonly Mock<IClientProxy> _mockClientProxy;
        // _hub: An instance of the ChatHub class (the SignalR hub being tested), configured with the mocked clients.
        private readonly ChatHub _hub;

        public SignalRTests()
        {
            _mockClients = new Mock<IHubCallerClients>();
            _mockClientProxy = new Mock<IClientProxy>();
            // Configures the mock so that when the All property of _mockClients is accessed (Clients.All), it returns the mocked _mockClientProxy object.
            // This simulates the behavior of accessing all connected clients in SignalR.
            _mockClients.Setup(clients => clients.All).Returns(_mockClientProxy.Object);

            // Creates an instance of the ChatHub and assigns the mocked IHubCallerClients to its Clients property. This allows the hub to interact with the mocked
            // clients instead of real SignalR clients during testing.
            _hub = new ChatHub
            {
                Clients = _mockClients.Object
            };
        }

        [Fact]
        public async Task SendMessage_ValidInput_BroadcastsToAllClients()
        {
            // Arrange
            string user = "Alice";
            string message = "Hello, SignalR!";

            // Act
            await _hub.SendMessage(user, message);

            // Assert
            // Uses Moq’s Verify method to check that the SendAsync method on the _mockClientProxy was called exactly once
            // Verifies that the SendMessage method correctly broadcasts the user and message to all clients by invoking the ReceiveMessage method on the client proxy.
            _mockClientProxy.Verify(
                client => client.SendAsync("ReceiveMessage", user, message, It.IsAny<CancellationToken>()),
                Times.Once());
        }
    }
```

## Example - Refactor to SOLID principle
```sh
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
```

```sh
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
```

```sh
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
```

