using System.Text.Json.Serialization;

namespace Todo.Domain.Transfers.Models
{
    public sealed record TaskDTO
    {
        public Guid Id { get; private set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        [JsonIgnore]
        public bool IsCompleted { get; private set; }

        [JsonIgnore]
        public DateTime? CompletedDate { get; private set; }

        [JsonIgnore]
        public string DeviceId { get; private set; }

        public TaskDTO(Guid id, DateTime createdDate, string title, string description, bool isCompleted, DateTime? completedDate, string deviceId)
        {
            Id = id;
            CreatedDate = createdDate;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            CompletedDate = completedDate;
            DeviceId = deviceId;
        }
    }
}
