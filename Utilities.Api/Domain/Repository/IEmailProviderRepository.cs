using Api.Utilities.Domain.Models;

namespace Api.Utilities.Domain.Repository
{
    public interface IEmailProviderRepository : IRepository<EmailProvider>
    {
        Task<EmailProvider> GetByName(string name);            
    }
}