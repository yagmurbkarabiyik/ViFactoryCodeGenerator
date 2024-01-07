using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Console
{
	public class ConsoleGenerator : IConsoleGenerator
	{
		private readonly IProjectGenerator _projectGenerator;
		private readonly IGenerator _generator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ConsoleGenerator(IProjectGenerator projectGenerator, IGenerator generator, IWebHostEnvironment webHostEnvironment)
        {
            _projectGenerator = projectGenerator;
            _generator = generator;
            _webHostEnvironment = webHostEnvironment;
        }

        public void GenerateConsoleProject(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);
			GenerateTemplates(projectGeneratorModel.OutputFolderPath);
			GenerateProgramCs(Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName));
            GenerateFileUtils(Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName));
		}
		public void GenerateProgramCs(string outputFilePath)
		{
			GeneratorModel generateProgramCs = new GeneratorModel()
			{
				ClassNameDefault = "Program",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\ProgramCs.txt",
				OutputFilePath = outputFilePath
			};

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
		public void GenerateFileUtils(string outputFilePath)
		{
			GeneratorModel generateFileUtils = new GeneratorModel
			{
				ClassNameDefault = "FileUtils",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\ConsoleApp\\Templates\\FileUtils.txt",
				OutputFilePath = outputFilePath
			};
			_generator.GenerateClass(generateFileUtils);
		}
		public void GenerateTemplates(string outputFolderPath)
		{
			var path = Path.Combine(outputFolderPath, "ViFactory", "Templates");
			Directory.CreateDirectory(path);

			string context = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\Context.txt");
			string filePath = Path.Combine(path, "Context.txt");
			File.WriteAllText(filePath, context);

			string createDto = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\CreateDto.txt");
			string dtoPath = Path.Combine(path, "CreateDto.txt");
			File.WriteAllText(dtoPath, createDto);

			string dalRepository = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\DalRepository.txt");
			string dalRepoPath = Path.Combine(path, "DalRepository.txt");
			File.WriteAllText(dalRepoPath, dalRepository);

			string iDalRepository = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\IDalRepository.txt");
			string iDalPath = Path.Combine(path, "IDalRepository.txt");
			File.WriteAllText(iDalPath, iDalRepository);

			string iService = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\IService.txt");
			string iServicePath = Path.Combine(path, "IService.txt");
			File.WriteAllText(iServicePath, iService);

			string service = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\Service.txt");
			string servicePath = Path.Combine(path, "Service.txt");
			File.WriteAllText(servicePath, service);

			string fluentApi = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\FluentApiMap.txt");
			string fluentApiPath = Path.Combine(path, "FluentApiMap.txt");
			File.WriteAllText(fluentApiPath, fluentApi);

			string unitOfWork = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\ConsoleApp\\Templates\\UnitOfWork.txt");
			string unitOfWorkPath = Path.Combine(path, "UnitOfWork.txt");
			File.WriteAllText(unitOfWorkPath, unitOfWork);

            string apiController = File.ReadAllText(Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Api\\Controller\\ApiController.txt");
            string apiControllerPath = Path.Combine(path, "ApiController.txt");
            File.WriteAllText(apiControllerPath, apiController);
        }
	}
}