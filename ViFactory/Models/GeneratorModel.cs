namespace ViFactory.Models
{
	public class GeneratorModel
	{
		public string NamespaceNameDefault { get; set; }
		public string ClassNameDefault { get; set; }
		public string? CurrentProjectName { get; set; }
		public Dictionary<string, string>? Properties{ get; set; }
		public Dictionary<string, string>? Methods { get; set; }
		public string? ConnectionString { get; set; }
		public string? EntityName { get; set; }
		public string? InterfaceName { get; set; }
		public string? DbContext { get; set; }
		public string?  ClassName { get; set; }
		public string InputFilePath { get; set; }
		public string OutputFilePath { get; set; }
	}
}