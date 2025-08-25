using Todo.Contracts.Contracts;
using Todo.Contracts.DTO;
using Todo.Contracts.DTO.Task.Request;
using Todo.Contracts.DTO.Task.Response;
using Todo.Contracts.Helpers;
using Todo.Domain.Contracts;
using Todo.Domain.Transfers.Models;

namespace Todo.Contracts.Managers
{
    internal sealed class TaskManager : ITaskManager
    {
        private readonly ITaskRepository taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<ResponseBase> CreateTaskAsync(CreateTaskRequest request)
        {
            await taskRepository.CreateTaskAsync(request.DeviceId, request.Title, request.Description);
            return new(System.Net.HttpStatusCode.Created);
        }

        public GetTasksResponse GetTasks(GetTasksRequest request)
        {
            var tasksResult = taskRepository.GetTasks(request.DeviceId);

            if (tasksResult.Value != null)
            {
                List<TaskDTO> tasks = tasksResult.Value;

                tasks = tasks.Where(t => !t.IsCompleted).OrderByDescending(t => t.CompletedDate).Take(5).ToList();
                return new(tasks);
            }

            throw HelperMethods.CreateException("Error getting Tasks", System.Net.HttpStatusCode.InternalServerError);
        }

        public async Task<ResponseBase> UpdateTaskAsync(UpdateTaskRequest request)
        {
            var updateResult = await taskRepository.CompleteTaskAsync(request.TaskId);

            if (!updateResult.IsSuccessful)
            {
                throw HelperMethods.CreateException(updateResult.Error.Message, System.Net.HttpStatusCode.NotFound);
            }

            return new(System.Net.HttpStatusCode.OK);
        }
    }
}
