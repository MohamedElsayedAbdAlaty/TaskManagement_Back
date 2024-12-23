using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Core.Task> GetTasks() => _context.Tasks.ToList();

    public Core.Task GetTask(int id) => _context.Tasks.Find(id);

    public Core.Task AddTask(Core.Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
    }

    public Core.Task UpdateTask(Core.Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
        return task;
    }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public List<Core.Task> Search(TaskSearchDto searchDto)
        {
           var query= _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(searchDto.Name))
                query = query.Where(t => t.Name.Contains(searchDto.Name));

            if ((searchDto.Status!=null))
                query = query.Where(t => (int)(t.Status)==searchDto.Status);

            if (searchDto.Priority != null)
                query = query.Where(t =>(int) t.Priority==searchDto.Priority);


            return query.ToList(); 
            
        }
    }
}
