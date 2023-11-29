namespace App.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T, K> 
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(K id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task DeleteAsync(K id);
    }
}
