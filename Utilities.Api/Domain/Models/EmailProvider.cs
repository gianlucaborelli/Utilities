namespace Api.Utilities.Domain.Models
{
    public class EmailProvider : Entity
    {
        public string Name { get; set; } = string.Empty;

        public EmailProvider()
        {}

        public EmailProvider(string name )
        {
            Id = Guid.NewGuid();
            Name = name;         
        }
    }
}