using ViFactory.Models;

namespace ViFactory.Services.Project
{
	public interface IProjectGenerator
	{
		public void GenerateProject(ProjectGeneratorModel projectGeneratorModel);
	}
}
