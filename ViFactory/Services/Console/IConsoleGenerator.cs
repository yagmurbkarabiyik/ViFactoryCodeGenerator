using ViFactory.Models;

namespace ViFactory.Services.Console
{
	public interface IConsoleGenerator
	{
		/// <summary>
		/// Create a Console Application Project
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
		public void GenerateConsoleProject(ProjectGeneratorModel projectGeneratorModel);
	}
}
