using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine($"Kullanıcı: {user}, Mesaj: {message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
