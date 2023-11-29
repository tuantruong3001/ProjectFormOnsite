namespace App.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T, K> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(K id);
        public Task<T> CreateAsync(T model);
        public Task<T> UpdateAsync(T model, K id);
        public Task DeleteAsync(K id);
    }
}
