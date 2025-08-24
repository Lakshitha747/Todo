using Domain.Contracts;
using Domain.Transfers;
using Domain.Transfers.Models;

namespace Domain.Repositories
{
    internal sealed class TaskRepository : ITaskRepository
    {
        private readonly TodoDbContext dbContext;

        public TaskRepository(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Result> CompleteTask(Guid taskId)
        {
            var task = dbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();

            if (task == null)
            {
                //return Result.Failure()
            }

            throw new NotImplementedException();
        }

        public Task<Result> CreateTask(string deviceId, string title, string description)
        {
            throw new NotImplementedException();
        }

        public Result<IEnumerable<TaskDTO>> GetTasks(string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
