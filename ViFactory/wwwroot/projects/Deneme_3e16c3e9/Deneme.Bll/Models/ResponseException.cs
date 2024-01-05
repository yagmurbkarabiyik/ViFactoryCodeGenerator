using System.Net;
using Deneme.Core.Helpers;
using Deneme.Bll.Enums;


namespace Deneme.Bll.Models
{
    public class ResponseException : Exception
	{
		public HttpStatusCode HttpStatusCode { get; set; }
		public ExceptionResponseType Type { get; set; }
		public List<string> Errors { get; set; }
		public Exception? Exception { get; set; }

		public ResponseException(HttpStatusCode httpStatusCode, ExceptionResponseType type, Exception? exception = null, List<string>? errors = null)
		{
			HttpStatusCode = httpStatusCode;
			Type = type;
			Exception = exception ?? new Exception("Unexpected error");
			Errors = new List<string>();
			Errors.AddRange(this.Exception.GetInnerExceptionMessages());

			if (errors != null)
				Errors.AddRange(errors);
		}
	}
}