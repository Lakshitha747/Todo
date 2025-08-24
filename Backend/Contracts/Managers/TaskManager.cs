using Contracts.Contracts;
using Contracts.DTO.Task.Request;
using Contracts.DTO.Task.Response;
using Contracts.Transfers;

namespace Contracts.Managers
{
    internal sealed class TaskManager : ITaskManager
    {
        public Task<ResponseBase> CreateTaskAsync(CreateTaskRequest request)
        {
            throw new NotImplementedException();
        }

        public GetTasksResponse GetTasks(GetTasksRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> UpdateTaskAsync(UpdateTaskRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
