using Api.Utilities.Data.Context;
using Api.Utilities.Domain.Repository;
using Api.Utilities.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Utilities.Data.Implementations
{
    public class EmailProviderImplementation : BaseRepository<EmailProvider>, IEmailProviderRepository
    {
        private DbSet<EmailProvider> _dataSet;

        public EmailProviderImplementation(AppDbContext context) : base(context)
        {
            _dataSet = context.Set<EmailProvider>();
        }

        public async Task<EmailProvider> GetByName(string name)
        {
            return await _dataSet.Where(d => d.Name.Equals(name)).SingleOrDefaultAsync();
        }
    }
}