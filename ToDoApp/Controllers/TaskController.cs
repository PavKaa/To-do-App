using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.DAL.Interface;
using ToDoApp.Domain.ViewModel.Task;
using ToDoApp.Services.Interface;

namespace ToDoApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var response = await taskService.GetAllTasks();

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                return View(response.Data);

            return RedirectToAction("Error");
        }

        [HttpGet]
		public async Task<IActionResult> GetTask(int id)
		{
			var response = await taskService.GetTask(id);

			if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
				

			return RedirectToAction("Error");
		}

		public async Task<IActionResult> GetTaskByName(string name)
        {
            var response = await taskService.GetTaskByName(name);

			if (response.StatusCode == Domain.Enum.StatusCode.Ok)
				return View("GetTask", response.Data);

			return RedirectToAction("Error");
		}

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await taskService.DeleteTask(id);

			if (response.StatusCode == Domain.Enum.StatusCode.Ok)
				return RedirectToAction("GetTasks");

			return RedirectToAction("Error");
		}

        [HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Save(int id)
        {
            if(id == 0)
            {
                return View();
            }

            var response = await taskService.GetTask(id);

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

  //      [HttpPost]
  //      public async Task<IActionResult> Save(TaskViewModel model)
  //      {
  //          if(!ModelState.IsValid) 
  //          {
		//		return RedirectToAction("Error");
		//	}

  //          if(model.Id == 0) 
  //          {
  //              var response = await taskService.CreateTask(model);

  //              if(response.StatusCode == Domain.Enum.StatusCode.Ok)
  //              {
  //                  return RedirectToAction("GetTasks");
		//	    }
  //          }
  //          else
  //          {
  //              var response = await taskService.Edit(model, model.Id);

  //              if(response.StatusCode == Domain.Enum.StatusCode.Ok)
  //              {
		//			return RedirectToAction("GetTasks");
		//	    }
  //          }
		//}
	}
}
