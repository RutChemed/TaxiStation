namespace UI.ApiController
{
    public interface IController<T>
    {   
        Task<ActionResult<IEnumerable<T>>> GetAsync();
        Task<ActionResult<T>> GetByIdAsync(int id);
        //Task<ActionResult<T>> CreateAsync(T entity);
        //Task<ActionResult<bool>> PutAsync(int id, T entity);
        Task<ActionResult<T>> DeleteAsync(int id);
    }
}
