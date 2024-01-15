using ViFactory.Models;

namespace ViFactory.Services.Generators
{
	public interface IGenerator
	{
		/// <summary>
		/// Create C# codes according to txt files and replaced 
		/// </summary>
		/// <param name="codeTemplate"></param>
		/// <param name="namespaceName"></param>
		/// <param name="className"></param>
		/// <param name="properties"></param>
		/// <param name="methods"></param>
		/// <param name="connectionString"></param>
		/// <param name="entityName"></param>
		/// <param name="interfaceName"></param>
		/// <param name="currentProjectName"></param>
		/// <param name="dbContext"></param>
		/// <returns></returns>
		public string GenerateCSharpCode(string codeTemplate, string namespaceName, string className, Dictionary<string, string>? properties, Dictionary<string, string>? methods,  string? connectionString, string? entityName, string? interfaceName, string? currentProjectName, string? dbContext);

		/// <summary>
		/// Create a new class 
		/// </summary>
		/// <param name="generateModel"></param>
		public void GenerateClass(GeneratorModel generateModel);
		/// <summary>
		/// Create a class of json
		/// </summary>
		/// <param name="generateModel"></param>
		public void GenerateJson(GeneratorModel generateModel);
	}
}