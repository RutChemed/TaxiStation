namespace Services.ServicesApi
{
    public interface IBlService<T>
    {   
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsyncById(int id);
    }
}
