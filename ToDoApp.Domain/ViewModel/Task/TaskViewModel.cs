using ToDoApp.Domain.Enum;

namespace ToDoApp.Domain.ViewModel.Task
{
	public class TaskViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Priority { get; set; }
	}
}
