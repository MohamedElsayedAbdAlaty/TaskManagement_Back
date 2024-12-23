using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Presentation
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {
            //// Save to database
            //await _chatService.SaveMessageAsync(user, message);

            //// Broadcast to all clients
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            var senderId = Context.User?.FindFirst("UserID")?.Value;
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(senderId))
            {
                await Clients.User(user).SendAsync("ReceiveMessage", senderId, message);
            }
        }
        public async Task LoadHistory()
        {
            var history = await _chatService.GetMessageHistoryAsync();
            await Clients.Caller.SendAsync("LoadHistory", history);
        }


        private static readonly Dictionary<string, string> ConnectedUsers = new();

        public override async Task OnConnectedAsync()
        {
            var username = Context.User?.Identity?.Name; // Assumes username is stored in User.Identity.Name
            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers[username] = Context.ConnectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = Context.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers.Remove(username);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToUser(string recipientUsername, string message)
        {
            if (ConnectedUsers.TryGetValue(recipientUsername, out var connectionId))
            {
                var senderUsername = Context.User?.Identity?.Name ?? "Anonymous";
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", senderUsername, message);
            }
        }
    }
}
