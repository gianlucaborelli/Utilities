namespace Api.Utilities.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}