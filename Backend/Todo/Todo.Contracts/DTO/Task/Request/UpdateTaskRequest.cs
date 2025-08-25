using System.ComponentModel.DataAnnotations;

namespace Todo.Contracts.DTO.Task.Request
{
    public sealed record UpdateTaskRequest
    {
        [Required]
        public Guid TaskId { get; private set; }

        public UpdateTaskRequest(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
