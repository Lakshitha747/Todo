using Todo.Contracts.Contracts;
using Todo.Contracts.DTO.Task.Request;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager taskManager;

        public TaskController(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        [HttpGet]
        public IActionResult GetTasks([FromQuery] string deviceId)
        {
            var result = taskManager.GetTasks(new(deviceId: deviceId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            var result = await taskManager.CreateTaskAsync(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("complete")]
        public async Task<IActionResult> CompleteTask(UpdateTaskRequest request)
        {
            var result = await taskManager.UpdateTaskAsync(request);
            return Ok(result);
        }
    }
}
