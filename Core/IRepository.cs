using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        Task GetTask(int id);
        Task AddTask(Task task);
        Task UpdateTask(Task task);
        void DeleteTask(int id);
        List<Task> Search(TaskSearchDto search);
    }

    public interface ITaskService
    {
        List<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        TaskDto CreateTask(TaskDto task);
        TaskDto UpdateTask(TaskDto task);
        void RemoveTask(int id);
        List<TaskDto> Search(TaskSearchDto search);
    }
}
