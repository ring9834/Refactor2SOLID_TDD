using ClassLib_Unitest;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace Xunitest
{
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
}
