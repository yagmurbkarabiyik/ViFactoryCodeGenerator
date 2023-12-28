using ViFactory.Models;

namespace ViFactory.Services.Generators
{
	public interface IGenerator
	{
		public string GenerateCSharpCode(string codeTemplate, string namespaceName, string className, Dictionary<string, string>? properties, Dictionary<string, string>? methods,  string? connectionString, string? entityName, string? interfaceName, string? currentProjectName, string? dbContext);

		public void GenerateClass(GeneratorModel generateModel);
	}
}