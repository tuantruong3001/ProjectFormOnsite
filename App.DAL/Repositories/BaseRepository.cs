using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories
{
    public class BaseRepository<T, K> : IBaseRepository<T, K> where T : class
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(K id)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                _dbSet.Remove(existingEntity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(K id)
        {
            var result = await _dbSet.FindAsync(id);
            return result!;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbSet.Update(entity);
            await _dataContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
