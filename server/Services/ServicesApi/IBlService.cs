namespace Services.ServicesApi
{
    public interface IBlService<T>
    {   
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> RemoveAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsyncById(int id);
    }
}
