using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    internal sealed class Task : BaseModel
    {
        [Required]
        public string Title { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public bool IsCompleted { get; private set; } = false;
        public DateTime? CompletedDate { get; private set; } = null;

        private Task() { }

        private Task(string addedBy, string title, string description) : base(addedBy)
        {
            Title = title;
            Description = description;
        }

        internal static Task CreateTask(string addedBy, string title, string description)
        {
            return new(addedBy, title, description);
        }

        internal static Task CompleteTask(Task task)
        {
            task.IsCompleted = true;
            task.CompletedDate = DateTime.UtcNow;
            return task;
        }
    }
}
