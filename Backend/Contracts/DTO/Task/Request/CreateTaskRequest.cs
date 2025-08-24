using System.ComponentModel.DataAnnotations;

namespace Contracts.DTO.Task.Request
{
    public sealed record CreateTaskRequest
    {
        [Required]
        public string DeviceId { get; private set; }

        [Required]
        public string Title { get; private set; }

        [Required]
        public string Description { get; private set; }

        public CreateTaskRequest(string deviceId, string title, string description)
        {
            DeviceId = deviceId;
            Title = title;
            Description = description;
        }
    }
}
