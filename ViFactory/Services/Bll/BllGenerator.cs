using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Bll
{
	public class BllGenerator : IBllGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BllGenerator(IGenerator generator, IProjectGenerator projectGenerator, IWebHostEnvironment webHostEnvironment)
        {
            _generator = generator;
            _projectGenerator = projectGenerator;
            _webHostEnvironment = webHostEnvironment;
        }

        public void GenerateBllLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);

			GenerateExceptionResponse(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Enums"));
			GenerateEmailSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateJwtSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateResponseCommon(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateResponseException(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateExceptionData(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateSmsNetGsmSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateEmailService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
			GenerateSmsNetGsmServices(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
			GenerateTokenService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
			GenerateMemoryCache(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
			GenerateUploadLocalService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
		}
		//Constant Classes
		private void GenerateExceptionResponse(string projectName, string outputFilePath)
		{
			GeneratorModel generateExceptionResponse = new GeneratorModel()
			{
				NamespaceNameDefault = projectName +".Bll.Enums",
				ClassNameDefault = "ExceptionResponseType",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Enums\\ExceptionResponseType.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			
			_generator.GenerateClass(generateExceptionResponse);
		}
		private void GenerateEmailSettings(string projectName, string outputFilePath)
		{
			GeneratorModel generateEmailSettings = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "EmailSettings",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\EmailSettings.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateEmailSettings);
		}
		private void GenerateJwtSettings(string projectName, string outputFilePath)
		{
			GeneratorModel generateJwtSettings = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "JwtSettings",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\JwtSettings.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateJwtSettings);
		}
		private void GenerateResponseCommon(string projectName, string outputFilePath)
		{
			GeneratorModel generateResponse = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "ResponseCommon",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\ResponseCommon.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateResponse);
		}
		private void GenerateResponseException(string projectName, string outputFilePath)
		{
			GeneratorModel generateResponseException = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "ResponseException",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\ResponseException.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateResponseException);
		}
		private void GenerateExceptionData(string projectName, string outputFilePath) 
		{
			GeneratorModel generateExceptionData = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "ResponseExceptionData",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\ResponseExceptionData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateExceptionData);
		}
		private void GenerateSmsNetGsmSettings(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmsNetGsmSettings = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Models",
				ClassNameDefault = "SmsNetGsmSettings",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Models\\SmsNetGsmSettings.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmsNetGsmSettings);
		}
		private void GenerateEmailService(string projectName, string outputFilePath)
		{
			GeneratorModel generateEmailService = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Common",
				ClassNameDefault = "EmailService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Services\\EmailService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateEmailService);
		}
		private void GenerateSmsNetGsmServices(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmsNetGsmService = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Common",
				ClassNameDefault = "SmsNetGsmServices",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Services\\SmsNetGsmService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmsNetGsmService);
		}
		private void GenerateTokenService(string projectName, string outputFilePath) 
		{
			GeneratorModel generateTokenService = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Common",
				ClassNameDefault = "TokenService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Services\\TokenService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateTokenService);
		}
		private void GenerateMemoryCache(string projectName, string outputFilePath)
		{
			GeneratorModel generateMemoryCache = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Common",
				ClassNameDefault = "MemoryCache",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Services\\MemoryCache.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateMemoryCache);
		}
		private void GenerateUploadLocalService(string projectName, string outputFilePath)
		{
			GeneratorModel generateUploadLocalService = new()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Common",
				ClassNameDefault = "UploadLocalService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Bll\\Services\\UploadLocalService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateUploadLocalService);
		}
	}
}
