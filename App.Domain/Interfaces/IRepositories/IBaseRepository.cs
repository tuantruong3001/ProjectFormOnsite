namespace App.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T, K> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(K id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(K id);
    }
}
