using ToDoApp.Domain.Enum;

namespace ToDoApp.Services.Response
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }

		public StatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}

	public interface IBaseResponse<T>
	{
		public string Description { get; set; }

		public StatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}
}
