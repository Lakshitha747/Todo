using Domain.Transfers;
using Domain.Transfers.Models;

namespace Domain.Contracts
{
    public interface ITaskRepository
    {
        Task<Result> CreateTask(string deviceId, string title, string description);
        Task<Result> CompleteTask(Guid taskId);
        Result<IEnumerable<TaskDTO>> GetTasks(string deviceId);
    }
}
