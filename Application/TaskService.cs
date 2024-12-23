using AutoMapper;
using Core;

namespace Application
{
    public class TaskService : ITaskService
    {
        private readonly Core.ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(Core.ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<Core.TaskDto> GetAllTasks() =>
            _mapper.Map<List<Core.TaskDto>>(_repository.GetTasks().ToList());

        public Core.TaskDto GetTaskById(int id) =>
            _mapper.Map<Core.TaskDto>(_repository.GetTask(id));

        public Core.TaskDto CreateTask(Core.TaskDto task)
        {
            TaskValidator validations =new TaskValidator();
            var res=  validations.Validate(task);
            if (res.Errors.Count()>0)
            {
                throw new Exception(res.Errors.ToString());

            }
            var entity = _mapper.Map<Core.Task>(task);
            return _mapper.Map<Core.TaskDto>(_repository.AddTask(entity));
        }

        public Core.TaskDto UpdateTask(Core.TaskDto task)
        {
            var entity = _mapper.Map<Core.Task>(task);
            return _mapper.Map<Core.TaskDto>(_repository.UpdateTask(entity));
        }

        public void RemoveTask(int id) => _repository.DeleteTask(id);

        public List<TaskDto> Search(TaskSearchDto search)
        {
           var res= _repository.Search(search);
            return _mapper.Map<List< Core.TaskDto>>(res);

        }
    }
}
