using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Enum
{
	public enum StatusCode
	{
		TaskNotFound = 4,
		Ok = 200,
		InternalServerError = 500
	}
}
