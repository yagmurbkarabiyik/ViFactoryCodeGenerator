using System.Net;

namespace Coffee.Bll.Models
{
    public class ResponseCommon 
    {
         public bool IsSuccess { get; set; } = true;
         public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
         public bool IsFailed => !IsSuccess;
      
    }
      public class ResponseCommon<T> : ResponseCommon
        {
            public T? Data { get; set; }
        }
}