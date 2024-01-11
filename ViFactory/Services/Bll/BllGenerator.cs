using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Bll
{
	/// <summary>
	/// Constant Classes Created for Bll Layer
	/// </summary>
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
			GenerateJwtSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateResponseCommon(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateResponseException(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateExceptionData(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateSmsNetGsmSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateTokenService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
			GenerateUploadLocalService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
            GenerateAppUserService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Concrete"));
            GenerateIAppUserService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Abstract"));
            GenerateAppUserRequestDto(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Dtos", "AppUserDtos"));
            GenerateAppUserResponseDto(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Dtos", "AppUserDtos"));
            GenerateSmtpSettings(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
            GenerateSmtpService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
            GenerateSmsNetGsmService(projectGeneratorModel.CurrentProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services", "Common"));
		}
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
		private void GenerateSmtpSettings(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmtpSettings = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "SmtpSettings",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\Models\\SmtpSettings.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmtpSettings);
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
		private void GenerateSmtpService(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmtpService = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Services.Common",
				ClassNameDefault = "SmtpServices",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\Services\\SmtpService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmtpService);
		}
		private void GenerateSmsNetGsmService(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmsNetGsmSettings = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Services.Common",
				ClassNameDefault = "SmsNetGsmService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\Services\\SmsNetGsmService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmsNetGsmSettings);
		}
		private void GenerateAppUserRequestDto(string projectName, string outputFilePath)
		{
			GeneratorModel generateAppUserDto = new()
			{
				NamespaceNameDefault = projectName + ".Bll.Dtos",
				ClassNameDefault = "AppUserRequestDtos",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\AppUserRequestDto.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateAppUserDto);	
		}
		private void GenerateAppUserResponseDto(string projectName, string outputFilePath)
		{
			GeneratorModel generateAppUserResponseDto = new()
			{
				NamespaceNameDefault = projectName + ".Bll.Dtos",
				ClassNameDefault = "AppUserResponseDto",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\AppUserResponseDto.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateAppUserResponseDto);

        }
        private void GenerateAppUserService(string projectName, string outputFilePath)
        {
            GeneratorModel generateAppUserService = new()
            {
				NamespaceNameDefault = projectName + ".Bll.Services.Concrete",
                ClassNameDefault = "AppUserService",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\Services\\AppUserService.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateAppUserService);

        }
		private void GenerateIAppUserService(string projectName, string outputFilePath)
		{
			GeneratorModel generateIAppUserService = new()
			{
				NamespaceNameDefault = projectName + ".Bll.Services.Abstract",
				ClassNameDefault  = "IAppUserService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Bll\\Services\\IAppUserService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateIAppUserService);
        }
    }
    
}
