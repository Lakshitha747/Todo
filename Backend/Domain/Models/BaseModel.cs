using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    internal class BaseModel
    {
        public Guid Id { get; private set; } = new Guid();
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        [Required]
        public string AddedByDevice { get; private set; }

        internal BaseModel() { }

        internal BaseModel(string addedBy)
        {
            AddedByDevice = addedBy;
        }
    }
}
