namespace DBAccess.DalApi
{
    public interface ICrud<T>
    {   
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(string id, T entity);
        Task<bool> RemoveAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsyncById(string id);
    }
}
