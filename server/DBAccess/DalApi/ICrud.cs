namespace DBAccess.DalApi
{
    public interface ICrud<T>
    {   
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsyncById(int id);
    }
}
