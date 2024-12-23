using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDtosController : ControllerBase
    {
        private readonly Core.ITaskService _service;

        public TaskDtosController(Core.ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTaskDtos() => Ok(_service.GetAllTasks());

        [HttpGet("{id}")]
        public IActionResult GetTaskDto(int id)
        {
            var TaskDto = _service.GetTaskById(id);
            return TaskDto != null ? Ok(TaskDto) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateTaskDto([FromBody] Core.TaskDto TaskDto) => Ok(_service.CreateTask(TaskDto));

        [HttpPut]
        public IActionResult UpdateTaskDto([FromBody] Core.TaskDto TaskDto) => Ok(_service.UpdateTask(TaskDto));

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskDto(int id)
        {
            _service.RemoveTask(id);
            return NoContent();
        }
        [HttpPost("search")]
        public async Task<IActionResult> SearchTasks([FromBody] TaskSearchDto searchDto)
        {
            var tasks = _service.Search(searchDto);
            return Ok(tasks);
        }
    }
}
