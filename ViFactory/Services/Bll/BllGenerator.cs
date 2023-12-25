using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Bll
{
	public class BllGenerator : IBllGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public BllGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateBllLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
		}
	}
}
