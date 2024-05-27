using Api.Utilities.Domain.Models;

namespace Api.Utilities.Domain.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync (Guid id);

        Task<T> SelectAsync (Guid id);

        Task<IEnumerable<T>> SelectAsync();

        Task<bool> ExistAsync(Guid id);
    }
}
