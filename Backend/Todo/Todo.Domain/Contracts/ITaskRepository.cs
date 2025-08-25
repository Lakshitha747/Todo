using Todo.Domain.Transfers;
using Todo.Domain.Transfers.Models;

namespace Todo.Domain.Contracts
{
    public interface ITaskRepository
    {
        Task<Result> CreateTaskAsync(string deviceId, string title, string description);
        Task<Result> CompleteTaskAsync(Guid taskId);
        Result<List<TaskDTO>> GetTasks(string deviceId);
    }
}
