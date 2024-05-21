using Microsoft.AspNetCore.SignalR;

namespace ScorerApp;

public class SignHub : Hub
{
    public async Task SendMessage()
{
    await Clients.All.SendAsync("SendMessage");
} 

}
