using Todo.Contracts.DTO;
using Todo.Contracts.DTO.Task.Request;
using Todo.Contracts.DTO.Task.Response;

namespace Todo.Contracts.Contracts
{
    public interface ITaskManager
    {
        Task<ResponseBase> CreateTaskAsync(CreateTaskRequest request);
        Task<ResponseBase> UpdateTaskAsync(UpdateTaskRequest request);
        GetTasksResponse GetTasks(GetTasksRequest request);
    }
}
