using System.Net;
using Coffee.Bll.Enums;
using Coffee.Core.Extensions;

namespace Coffee.Bll.Models
{
    public class ResponseException : Exception
	{
		public HttpStatusCode StatusCode { get; set; }
		public ExceptionResponseType Type { get; set; }
		public List<string> Errors { get; set; }
		public Exception? Exception { get; set; }

		public ResponseException(HttpStatusCode statusCode, ExceptionResponseType type, Exception? exception = null, List<string>? errors = null)
		{
			StatusCode = statusCode;
			Type = type;
			Exception = exception ?? new Exception("Unexpected error");
			Errors = new List<string>();
			Errors.AddRange(this.Exception.GetInnerExceptionMessages());

			if (errors != null)
				Errors.AddRange(errors);
		}
	}
}