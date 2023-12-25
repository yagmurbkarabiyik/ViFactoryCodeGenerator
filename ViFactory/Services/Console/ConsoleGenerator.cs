using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Console
{
	public class ConsoleGenerator : IConsoleGenerator
	{
		private readonly IProjectGenerator _projectGenerator;
		private readonly IGenerator _generator;
		public ConsoleGenerator(IProjectGenerator projectGenerator, IGenerator generator)
		{
			_projectGenerator = projectGenerator;
			_generator = generator;
		}

		public void GenerateConsoleProject(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
			GenerateProgramCs("C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\VFConsoleApp\\");
		}

		public void GenerateProgramCs(string outputFilePath)
		{
			GeneratorModel generateProgramCs = new GeneratorModel()
			{
				ClassNameDefault = "Program",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\ProgramCs.txt",
				OutputFilePath = outputFilePath
			};
			_generator.GenerateClass(generateProgramCs);
		}
	}
}