using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Dtos
{
	public class DtoGenerator : IDtoGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public DtoGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}

		public void GenerateDtoLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
		}
	}
}
