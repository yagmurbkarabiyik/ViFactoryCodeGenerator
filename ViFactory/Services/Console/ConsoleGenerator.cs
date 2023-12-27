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

			string emailService = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\EmailService.txt");
			string emailServicePath = Path.Combine(path, "EmailService.txt");
			File.WriteAllText(emailServicePath, emailService);

			string emailSettins = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\EmailSettings.txt");
			string emailSettingsPath = Path.Combine(path, "EmailSettings.txt");
			File.WriteAllText(emailSettingsPath, emailSettins);

			string exceptionResponse = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\ExceptionResponseType.txt");
			string responseTypePath = Path.Combine(path, "ExceptionResponseType.txt");
			File.WriteAllText(responseTypePath, exceptionResponse);

			string iDalRepository = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\IDalRepository.txt");
			string iDalPath = Path.Combine(path, "IDalRepository.txt");
			File.WriteAllText(iDalPath, iDalRepository);

			string iService = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\IService.txt");
			string iServicePath = Path.Combine(path, "IService.txt");
			File.WriteAllText(iServicePath, iService);

			string jwtSettings = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\JwtSettings.txt");
			string jwtSettingsPath = Path.Combine(path, "JwtSettings.txt");
			File.WriteAllText(jwtSettingsPath, jwtSettings);

			string memoryCache = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\MemoryCacheService.txt");
			string memoryCachePath = Path.Combine(path, "MemoryCacheService.txt");
			File.WriteAllText(memoryCachePath, memoryCache);

			string repository = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\Repository.txt");
			string repositoryPath = Path.Combine(path, "Repository.txt");
			File.WriteAllText(repositoryPath, repository);

			string responseCommon = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\ResponseCommon.txt");
			string responseCommonPath = Path.Combine(path, "ResponseCommon.txt");
			File.WriteAllText(responseCommonPath, responseCommon);

			string responseException = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\ResponseException.txt");
			string responseExceptionPath = Path.Combine(path, "ResponseException.txt");
			File.WriteAllText(responseExceptionPath, responseException);

			string responseExceptionData = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\ResponseExceptionData.txt");
			string responseExceptionDataPath = Path.Combine(path, "ResponseExceptionData.txt");
			File.WriteAllText(responseExceptionDataPath, responseExceptionData);

			string service = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\Service.txt");
			string servicePath = Path.Combine(path, "Service.txt");
			File.WriteAllText(servicePath, service);

			string smsNetGsm = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\SmsNetGsm.txt");
			string smsNetGsmPath = Path.Combine(path, "SmsNetGsm.txt");
			File.WriteAllText(smsNetGsmPath, smsNetGsm);

			string smsNetGsmService = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\SmsNetGsmService.txt");
			string smsNetGsmServicePath = Path.Combine(path, "SmsNetGsmService.txt");
			File.WriteAllText(smsNetGsmServicePath, smsNetGsmService);

			string tokenService = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\TokenService.txt");
			string tokenServicePath = Path.Combine(path, "TokenService.txt");
			File.WriteAllText(tokenServicePath, tokenService);

			string unitOfWork = File.ReadAllText("C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\ConsoleApp\\Templates\\UnitOfWork.txt");
			string unitOfWorkPath = Path.Combine(path, "UnitOfWork.txt");
			File.WriteAllText(unitOfWorkPath, unitOfWork);
		}
	}
}