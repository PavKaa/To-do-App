using System.Threading.Tasks;
using ToDoApp.Domain.Entity;
using ToDoApp.Domain.ViewModel.Task;
using ToDoApp.Services.Response;

namespace ToDoApp.Services.Interface
{
    public interface ITaskService
    {
        Task<IBaseResponse<IEnumerable<TaskEntity>>> GetAllTasks();

        Task<IBaseResponse<TaskEntity>> GetTask(int id);

        Task<IBaseResponse<TaskEntity>> GetTaskByName(string name);

		Task<IBaseResponse<TaskEntity>> Edit(TaskViewModel viewModel, int id);

		Task<IBaseResponse<bool>> DeleteTask(int id);

        Task<IBaseResponse<TaskViewModel>> CreateTask(TaskViewModel viewModel);
    }
}
