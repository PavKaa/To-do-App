namespace ToDoApp.DAL.Interface
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> Select();

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);
    }
}
