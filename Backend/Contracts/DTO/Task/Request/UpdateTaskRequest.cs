using System.ComponentModel.DataAnnotations;

namespace Contracts.DTO.Task.Request
{
    public sealed record UpdateTaskRequest
    {
        [Required]
        public string TaskId { get; private set; }

        public UpdateTaskRequest(string taskId)
        {
            TaskId = taskId;
        }
    }
}
