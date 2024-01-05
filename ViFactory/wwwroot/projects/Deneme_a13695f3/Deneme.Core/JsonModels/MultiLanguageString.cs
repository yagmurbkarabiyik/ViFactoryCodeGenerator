namespace Deneme.Core.Core.JsonModels.Core.JsonModels
{
    public class MultiLanguageString
    {
        public string Language { get; set; } = null!;
        public string? Value { get; set; }

        public MultiLanguageString()
        {
                
        }
        public MultiLanguageString(string language, string? value = null)
        {
            Language = language;
            Value = value;
        }
    }
}