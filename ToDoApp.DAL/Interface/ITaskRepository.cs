using ToDoApp.Domain.Entity;

namespace ToDoApp.DAL.Interface
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
        Task<TaskEntity> GetByName(string name);
    }
}
