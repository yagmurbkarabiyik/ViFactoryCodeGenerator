using ViFactory.Models;

namespace ViFactory.Models
{
	public class SolutionGeneratorModel
	{
		public string NamespaceName { get; set; }
		public string SolutionName { get; set; }
		public string SolutionFilePath { get; set; }
		public string TargetFilePath { get; set; }
		public string ProjectGuid { get; set; }
	}
}