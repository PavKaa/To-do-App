using System.Data.SqlTypes;
using ToDoApp.DAL.Interface;
using ToDoApp.Domain.Entity;
using ToDoApp.Domain.Enum;
using ToDoApp.Domain.ViewModel.Task;
using ToDoApp.Services.Interface;
using ToDoApp.Services.Response;

namespace ToDoApp.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repository)
        {
            this.repository = repository;
        }

		public async Task<IBaseResponse<IEnumerable<TaskEntity>>> GetAllTasks()
		{
			var response = new BaseResponse<IEnumerable<TaskEntity>>();
			try
			{
				var tasks = await repository.Select();

				if(tasks.Count() == 0)
				{
					response.Description = "Найдено 0 элементов.";
					response.StatusCode = StatusCode.Ok;
					return response;
				}

				response.Data = tasks;
				response.Description = $"Найдено {tasks.Count()} элементов.";
				response.StatusCode = StatusCode.Ok;
				return response;
			}
			catch(Exception ex) 
			{
				return new BaseResponse<IEnumerable<TaskEntity>>()
				{
					Description = $"[GetTasks] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<TaskViewModel>> CreateTask(TaskViewModel viewModel)
		{
			var response = new BaseResponse<TaskViewModel>();

			try
			{
				var task = new TaskEntity
				{
					Name = viewModel.Name,
					Description = viewModel.Description,
					Priority = (Priority)Convert.ToInt32(viewModel.Priority)
				};

				await repository.Create(task);

				response.Description = "Объект успешно создан.";
				response.StatusCode = StatusCode.Ok;
				response.Data = viewModel;
				return response;
			}
			catch (Exception ex)
			{ 
				return new BaseResponse<TaskViewModel>()
				{
					Description = $"[CreateTask] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError,
					Data = viewModel
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeleteTask(int id)
		{
			var response = new BaseResponse<bool>();
			try
			{
				var task = await repository.Get(id);

				if(task == null) 
				{
					response.Description = "Указанный объект отсутствует в базе данных.";
					response.StatusCode = StatusCode.Ok;
					return response;
				}

				await repository.Delete(task);
				response.Data = true;
				response.StatusCode = StatusCode.Ok;
				return response;
			}
			catch(Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[DeleteTask] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<TaskEntity>> GetTask(int id)
		{
			var response = new BaseResponse<TaskEntity>();
			try
			{
				var task = await repository.Get(id);
				
				if( task == null ) 
				{
					response.Description = "Элемент с указанным id не найден.";
					response.StatusCode = StatusCode.TaskNotFound;
					return response;
				}

				response.Data = task;
				response.StatusCode = StatusCode.Ok;
				return response;
			}
			catch(Exception ex) 
			{
				return new BaseResponse<TaskEntity>()
				{
					Description = $"[GetTask] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<TaskEntity>> GetTaskByName(string name)
		{
			var response = new BaseResponse<TaskEntity>();
			try
			{
				var task = await repository.GetByName(name);

				if (task == null)
				{
					response.Description = "Элемент с указанным полем Name не найден.";
					response.StatusCode = StatusCode.TaskNotFound;
					return response;
				}

				response.Data = task;
				response.StatusCode = StatusCode.Ok;
				return response;
			}
			catch (Exception ex)
			{
				return new BaseResponse<TaskEntity>()
				{
					Description = $"[GetTaskByName] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<TaskEntity>> Edit(TaskViewModel viewModel, int id)
		{
			var response = new BaseResponse<TaskEntity>();

			try
			{
				var task = await repository.Get(id);

				if(task == null)
				{
					response.Description = "Указанный объект отсутствует в базе данных.";
					response.StatusCode = StatusCode.TaskNotFound;
					return response;
				}

				task.Name = viewModel.Name;
				task.Description = viewModel.Description;
				//task.Priority = viewModel.Priority;

				response.Data = await repository.Update(task);
				response.StatusCode = StatusCode.Ok;
				return response;
			}
			catch (Exception ex)
			{
				return new BaseResponse<TaskEntity>()
				{
					Description = $"[Edit] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}
