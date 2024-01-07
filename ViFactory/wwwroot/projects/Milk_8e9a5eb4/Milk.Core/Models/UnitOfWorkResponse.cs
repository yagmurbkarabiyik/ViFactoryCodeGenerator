namespace Milk.Core.Models
{
    public class UnitOfWorkResponse
    {
         public int? Result { get; set; }
         public Exception? Exception { get; set; }
         public UnitOfWorkResponse(int result)
         {
            Result = result;
         }

        public UnitOfWorkResponse(Exception exception)
        {
            Exception = exception;
        }
    }
}