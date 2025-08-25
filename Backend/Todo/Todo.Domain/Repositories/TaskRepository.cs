using Todo.Domain.Contracts;
using Todo.Domain.Models;
using Todo.Domain.Transfers;
using Todo.Domain.Transfers.Models;
using Todo.Domain.Validations;

namespace Todo.Domain.Repositories
{
    internal sealed class TaskRepository : ITaskRepository
    {
        private readonly TodoDbContext dbContext;

        public TaskRepository(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> CompleteTaskAsync(Guid taskId)
        {
            var task = dbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();

            if (task == null)
            {
                return Result.Failure(TasksValidations.TaskNotFound);
            }

            task = TodoTask.CompleteTask(task);

            dbContext.Tasks.Update(task);
            await dbContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> CreateTaskAsync(string deviceId, string title, string description)
        {
            var newTask = TodoTask.CreateTask(deviceId, title, description);

            dbContext.Tasks.Add(newTask);
            await dbContext.SaveChangesAsync();

            return Result.Success();
        }

        public Result<List<TaskDTO>> GetTasks(string deviceId)
        {
            var tasks = dbContext.Tasks.Where(t => t.AddedByDevice == deviceId).AsEnumerable();

            List<TaskDTO> resultTasks = [];

            foreach (var task in tasks)
            {
                resultTasks.Add(new(task.Id, task.CreatedDate, task.Title, task.Description, task.IsCompleted, task.CompletedDate, task.AddedByDevice));
            }

            return Result<List<TaskDTO>>.Success(resultTasks);
        }
    }
}
