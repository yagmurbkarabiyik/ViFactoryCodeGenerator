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
			GenerateTemplates(projectGeneratorModel.OutputFolderPath);
			GenerateProgramCs(Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName));
		}
		public void GenerateProgramCs(string outputFilePath)
		{
			GeneratorModel generateProgramCs = new GeneratorModel()
			{
				ClassNameDefault = "Program",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\ProgramCs.txt",
				OutputFilePath = outputFilePath
			};
			//_generator.GenerateClass(generateProgramCs);

			string textFilePath = generateProgramCs.InputFilePath;
			string codeTemplate = File.ReadAllText(textFilePath);
			string modelsFolderPath = Path.Combine(generateProgramCs.OutputFilePath);

			// Create the Models folder if it doesn't exist
			if (!Directory.Exists(modelsFolderPath))
			{
				Directory.CreateDirectory(modelsFolderPath);
			}

			// Create the path for the new class file inside the Models folder
			string classFilePath = Path.Combine(modelsFolderPath, $"{generateProgramCs.ClassNameDefault}.cs");

			File.WriteAllText(classFilePath, codeTemplate);
		}
		public void GenerateTemplates(string outputFolderPath)
		{
			var path = Path.Combine(outputFolderPath, "ViFactory", "Templates");
			Directory.CreateDirectory(path);

			string context = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\Context.txt");
			string filePath = Path.Combine(path, "Context.txt");
			File.WriteAllText(filePath, context);

			string createDto = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\CreateDto.txt");
			string dtoPath = Path.Combine(path, "CreateDto.txt");
			File.WriteAllText(dtoPath, createDto);

			string dalRepository = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\DalRepository.txt");
			string dalRepoPath = Path.Combine(path, "DalRepository.txt");
			File.WriteAllText(dalRepoPath, dalRepository);

			string iDalRepository = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\IDalRepository.txt");
			string iDalPath = Path.Combine(path, "IDalRepository.txt");
			File.WriteAllText(iDalPath, iDalRepository);

			string iService = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\IService.txt");
			string iServicePath = Path.Combine(path, "IService.txt");
			File.WriteAllText(iServicePath, iService);

			string service = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\Service.txt");
			string servicePath = Path.Combine(path, "Service.txt");
			File.WriteAllText(servicePath, service);

			string fluentApi = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\FluentApiMap.txt");
			string fluentApiPath = Path.Combine(path, "FluentApiMap.txt");
			File.WriteAllText(fluentApiPath, fluentApi);

			string unitOfWork = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\UnitOfWork.txt");
			string unitOfWorkPath = Path.Combine(path, "UnitOfWork.txt");
			File.WriteAllText(unitOfWorkPath, unitOfWork);
		}
	}
}