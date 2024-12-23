using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ChatRepository : IChatRepository
    {
        private readonly TaskDbContext _dbContext;

        public ChatRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task SaveMessageAsync(ChatMessage message)
        {
            _dbContext.ChatMessages.Add(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ChatMessage>> GetMessageHistoryAsync()
        {
            return await _dbContext.ChatMessages
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

      
    }
}
