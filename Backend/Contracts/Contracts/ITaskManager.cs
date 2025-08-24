using Contracts.DTO.Task.Request;
using Contracts.DTO.Task.Response;
using Contracts.Transfers;

namespace Contracts.Contracts
{
    public interface ITaskManager
    {
        Task<ResponseBase> CreateTaskAsync(CreateTaskRequest request);
        Task<ResponseBase> UpdateTaskAsync(UpdateTaskRequest request);
        GetTasksResponse GetTasks(GetTasksRequest request);
    }
}
