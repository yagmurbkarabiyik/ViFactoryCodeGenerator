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
			//GenerateEmailSettings();
			//GenerateEmailService();
			//GenerateSmsNetGsmSettings();
			//GenerateSmsNetGsmService();
			//GenerateResponseResponseCommon();
			//GenerateResponseException();
			//GenerateResponseExceptionData();
			//GenerateJwtSettings();
			//GenerateTokenService();
			//GenerateExceptionResponse();
		}

		//Generate Bll Classes
		//private void GenerateEmailSettings()
		//{
		//	GeneratorModel generateEmailSettingsModel = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "EmailSettings",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\EmailSettings.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\",
		//		Properties = new Dictionary<string, string>
		//		{
		//			{ "DisplayName", "string?" },
		//			{ "From", "string?" },
		//			{ "UserName", "string?" },
		//			{ "Password", "string?" },
		//			{ "Host", "string?" },
		//			{ "Port", "int" },
		//			{ "UseSSL", "bool" },
		//			{ "UseStartTls", "bool" }
		//		} 
		//	};
		//	_generator.GenerateClass(generateEmailSettingsModel);

		//}
		//private void GenerateEmailService()
		//{
		//	GeneratorModel generateEmailServiceModel = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "EmailService",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Services\\EmailService.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Services\\Common\\",
		//	};
		//	_generator.GenerateClass(generateEmailServiceModel);
		//}
		//private void GenerateSmsNetGsmSettings()
		//{
		//	GeneratorModel generateSmsNetGsmSettings = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "SmsNetGsmSettings",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\SmsNetGsmSettings.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\"
		//	};
		//	_generator.GenerateClass(generateSmsNetGsmSettings);
		//}
		//private void GenerateSmsNetGsmService()
		//{
		//	GeneratorModel generateSmsNetGsmService = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "SmsNetGsmService",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Services\\SmsNetGsmService.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Services\\Common"
		//	};
		//	_generator.GenerateClass(generateSmsNetGsmService);
		//}
		//private void GenerateResponseResponseCommon()
		//{
		//	GeneratorModel generateResponse = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "ResponseCommon",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\ResponseCommon.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\"
		//	};
		//	_generator.GenerateClass(generateResponse);
		//}
		//private void GenerateResponseException()
		//{
		//	GeneratorModel generateResponseException = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "ResponseException",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\ResponseException.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\"
		//	};
		//	_generator.GenerateClass(generateResponseException);
		//}
		//private void GenerateResponseExceptionData()
		//{
		//	GeneratorModel generateResponseExceptionData = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "ResponseExceptionData",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\ResponseExceptionData.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\"
		//	};
		//	_generator.GenerateClass(generateResponseExceptionData);
		//}
		//private void GenerateJwtSettings()
		//{
		//	GeneratorModel generateJwtSettings = new()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "JwtSettings",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Models\\JwtSettings.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Models\\"
		//	};

		//	_generator.GenerateClass(generateJwtSettings);
		//}
		//private void GenerateTokenService()
		//{
		//	GeneratorModel generateTokenService = new GeneratorModel()
		//	{
		//		NamespaceNameDefault = "TokenService",
		//		ClassNameDefault = "TokenService",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Services\\TokenService.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Services\\Common"
		//	};
		//	_generator.GenerateClass(generateTokenService);
		//}
		//private void GenerateExceptionResponse()
		//{
		//	GeneratorModel generateExceptionResponse = new GeneratorModel()
		//	{
		//		NamespaceNameDefault = "ViFactoryNewSolution",
		//		ClassNameDefault = "ExceptionResponseType",
		//		InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Bll\\Enums\\ExceptionResponseType.txt",
		//		OutputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactoryNew\\ViFactoryNew.Bll\\Enums\\"
		//	};
		//	_generator.GenerateClass(generateExceptionResponse);
		//}
	}
}
