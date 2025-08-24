namespace Domain.Transfers.Models
{
    public sealed record TaskDTO
    {
        public string DeviceId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletedDate { get; private set; }

        public TaskDTO(string deviceId, DateTime createdDate, string title, string description, bool isCompleted, DateTime? completedDate)
        {
            DeviceId = deviceId;
            CreatedDate = createdDate;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            CompletedDate = completedDate;
        }
    }
}
