using Microsoft.AspNetCore.SignalR;

namespace Phetolo.Math28.API.Hubs;

public class WinnerNotificationHub : Hub
{
    private readonly ILogger<WinnerNotificationHub> _logger;
    public WinnerNotificationHub(ILogger<WinnerNotificationHub> logger)
    {
        _logger = logger;
    }
    public async Task SendWinnerNotification(string message)
    {
        await Clients.All.SendAsync("ReceiveWinnerNotification", message);
    }

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
}
