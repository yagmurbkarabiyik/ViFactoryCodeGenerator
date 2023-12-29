using Microsoft.AspNetCore.Http;

namespace Coffee.Core.Core.JsonModels.Core.JsonModels
{
    public class MultiLanguageFormFile
    {
        public string Language { get; set; } = null!;
        public IFormFile? File { get; set; }
        public string? Url { get; set; }
    }
}