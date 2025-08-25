using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Models
{
    internal sealed class TodoTask : BaseModel
    {
        [Required]
        public string Title { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public bool IsCompleted { get; private set; } = false;
        public DateTime? CompletedDate { get; private set; } = null;

        [Required]
        public string AddedByDevice { get; private set; }

        private TodoTask() { }

        private TodoTask(string addedBy, string title, string description) : base()
        {
            Title = title;
            Description = description;
            AddedByDevice = addedBy;
        }

        internal static TodoTask CreateTask(string addedBy, string title, string description)
        {
            return new(addedBy, title, description);
        }

        internal static TodoTask CompleteTask(TodoTask task)
        {
            task.IsCompleted = true;
            task.CompletedDate = DateTime.UtcNow;
            return task;
        }
    }
}
