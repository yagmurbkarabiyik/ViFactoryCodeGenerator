using System.Net;

namespace aws.Bll.Models
{
    public class ResponseCommon
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

    }

    public class ResponseCommon<T> : ResponseCommon
    {
        public T? Data { get; set; }
    }
}