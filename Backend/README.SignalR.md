# SignalR
SignalR enables real-time bi-directional communication between clients and servers. SignalR uses **WebSockets** as one of its transport mechanism, falling back to other transports (e.g. **Server-sent Events, Long polling**)

## SignalR Hub
SignalR are a high-level abstraction that simplifies real-time communication between clients and servers. Hub is a central gateway for clients to connect and communicate with the server.

### Key Features

1. RPC (Remote Procedure Call): Hubs enable clients to call server-side methods and vice versa
2. Connection management: Hubs handle connection state, including OnConnected and DisConnected events
3. Client targeting: Hubs provide APIs to target specific clients or groups

### How Hubs works
1. Clients connect to a Hub a URL (e.g. /winnerNotificationHub)
2. The hub exposes methods that clients can call
3. Clients can invoke server-side methods using the Hub's API
4. The Hub can also invoke client-side methods

### Implement OnConnected and DisConnected method in the Hub implementation
The OnConnected and DisConnected events provide a way to manage client connections. **OnReconnected** is another event method that can be used (less common).

```csharp
 public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client connected: {this.Context.ConnectionId}");
        // Logic to handle when a client connects
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Client disconnected: {this.Context.ConnectionId}");
        // Logic to handle when a client disconnects
        return base.OnDisconnectedAsync(exception);
    }
```

### Scaling out

1. **Backplane**: Use a Backplane (e.g. Redis, Azure Service Bus) to sync state across multiple servers
2. **Sticky sessions**: Use sticky sessions to route requests from a client to the same server

### Azure SignalR Service
Is a managed SignalR service that simplifies real-time communications in apps especially when it comes to scaling and authentication.