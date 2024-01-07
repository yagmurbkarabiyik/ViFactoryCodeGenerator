namespace IceTea.Core.Core.JsonModels.Core.JsonModels
{
    public class MultiLanguageListString
    {
        public string Language { get; set; } = null!;

        public List<string>? Value { get; set; }
        public MultiLanguageListString()
        {
            
        }
        public MultiLanguageListString(string language, List<string>? value = null)
        {
            Language = language;
            Value = value;
        }
    }
}