namespace App.Domain.Interfaces.IServices
{
    public interface IBaseService<T, K>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(K id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(K id);
    }
}
