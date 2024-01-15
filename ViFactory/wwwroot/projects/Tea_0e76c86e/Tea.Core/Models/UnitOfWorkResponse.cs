namespace Tea.Core.Models
{
    public class UnitOfWorkResponse
    {
        public int? Result { get; set; }
        public Exception? Exception { get; set; }
        public bool IsSuccess => Result > 0 && Exception == null;

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