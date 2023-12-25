using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Dal
{
	public class DalGenerator : IDalGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public DalGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateDalLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
		}
	}
}


