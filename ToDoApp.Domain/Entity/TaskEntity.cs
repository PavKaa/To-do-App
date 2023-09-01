using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Enum;

namespace ToDoApp.Domain.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }

        [ForeignKey("User")]
        public string UserLogin { get; set; }
		[Required]
		public User User { get; set; }
    }
}
