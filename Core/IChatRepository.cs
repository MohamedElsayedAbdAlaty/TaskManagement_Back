using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IChatRepository
    {
        System.Threading.Tasks.Task SaveMessageAsync(ChatMessage message);
        Task<List<ChatMessage>> GetMessageHistoryAsync();
    }
}
