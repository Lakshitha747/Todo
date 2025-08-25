namespace Todo.Domain.Models
{
    internal class BaseModel
    {
        public Guid Id { get; private set; } = new Guid();
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        internal BaseModel() { }
    }
}
