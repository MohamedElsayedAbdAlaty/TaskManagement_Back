using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Application
{
    public class ChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task SaveMessageAsync(string user, string message)
        {
            var chatMessage = new ChatMessage
            {
                User = user,
                Message = message,
                Timestamp = DateTime.UtcNow
            };

             _chatRepository.SaveMessageAsync(chatMessage);
        }

        public async Task<List<ChatMessage>> GetMessageHistoryAsync()
        {
            return await _chatRepository.GetMessageHistoryAsync();
        }
    }
}
