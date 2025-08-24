using Domain.Transfers.Models;

namespace Contracts.DTO.Task.Response
{
    public sealed record GetTasksResponse
    {
        public List<TaskDTO> Tasks { get; private set; }

        public GetTasksResponse(List<TaskDTO> tasks)
        {
            Tasks = tasks;
        }
    }
}
