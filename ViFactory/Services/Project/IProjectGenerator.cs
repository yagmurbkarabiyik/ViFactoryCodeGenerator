using ViFactory.Models;

namespace ViFactory.Services.Project
{
	public interface IProjectGenerator
	{
		/// <summary>
		/// Create a new project 
		/// </summary>
		/// <param name="projectGeneratorModel"></param>
		public void GenerateProject(ProjectGeneratorModel projectGeneratorModel);
	}
}
