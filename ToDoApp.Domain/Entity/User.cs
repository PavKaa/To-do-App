using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Entity
{
	public class User
	{
		[Key]
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public IEnumerable<TaskEntity> Tasks { get; set; }
	}
}
