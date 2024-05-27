using Api.Utilities.Data.Context;
using Api.Utilities.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Utilities.Domain.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }        

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();

                item.CreatedAt = DateTime.UtcNow;

                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id)) 
                        ?? throw new ArgumentException($"Item with ID {item.Id} not found in the database.");
                        
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataSet.Remove(result);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}