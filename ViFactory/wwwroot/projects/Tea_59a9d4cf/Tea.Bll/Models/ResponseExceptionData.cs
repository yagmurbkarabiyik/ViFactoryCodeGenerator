using Tea.Bll.Enums;

namespace Tea.Bll.Models
{
    public class ResponseExceptionData 
    {
        public ExceptionResponseType Type { get; set; }
        public List<string>? Errors { get; set; }
        public Dictionary<string, List<string>?>? ValidationErrors { get; set; }
    }
}