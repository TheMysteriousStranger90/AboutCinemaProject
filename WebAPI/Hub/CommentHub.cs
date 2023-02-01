using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hub;

public class CommentHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendAsync(string message)
    {
        await this.Clients.All.SendAsync("send",message);
    }
}