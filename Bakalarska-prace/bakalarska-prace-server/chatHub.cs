using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // Mapování: userId -> connectionId
    private static Dictionary<string, string> connectedUsers = new();

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var user = connectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId);
        if (!string.IsNullOrEmpty(user.Key))
        {
            connectedUsers.Remove(user.Key);
            Console.WriteLine($"User {user.Key} disconnected");
        }
        return base.OnDisconnectedAsync(exception);
    }

    // Přihlášení uživatele
    public Task Register(string userId)
    {
        connectedUsers[userId] = Context.ConnectionId;
        Console.WriteLine($"User registered: {userId}");
        return Task.CompletedTask;
    }

    // Poslat zprávu jen mezi dvěma uživateli
    public async Task SendPrivateMessage(string fromUser, string toUser, string message)
    {
        if (connectedUsers.TryGetValue(toUser, out var connectionId))
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", fromUser, message);
        }
    }
}
