using Todo.Domain.Transfers;

namespace Todo.Domain.Validations
{
    public static class TasksValidations
    {
        public static readonly Error TaskNotFound = new("Task not found");
    }
}
