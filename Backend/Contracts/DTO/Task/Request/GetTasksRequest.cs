using System.ComponentModel.DataAnnotations;

namespace Contracts.DTO.Task.Request
{
    public sealed record GetTasksRequest
    {
        [Required]
        public string DeviceId { get; private set; }

        public GetTasksRequest(string deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
