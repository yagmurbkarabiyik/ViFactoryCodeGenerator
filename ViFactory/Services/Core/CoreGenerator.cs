using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Core
{
    public class CoreGenerator : ICoreGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
		public CoreGenerator(IGenerator generator, IProjectGenerator projectGenerator)
		{
			_generator = generator;
			_projectGenerator = projectGenerator;
		}
		public void GenerateCoreLayer(ProjectGeneratorModel projectGeneratorModel)
		{
			_projectGenerator.GenerateProject(projectGeneratorModel);

			GenerateIRepository(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath,projectGeneratorModel.ProjectName,"Services"));
			GenerateIBaseEntity(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateIUnitOfWork(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateUnitOfWorkResponse(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GeneratePaginationRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GeneratePaginationResponse(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateISmsNetGsmService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateSmsNetGsmSendData(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateIEmailService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateEmailSendData(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateIMemoryCache(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateDbEntityState(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Enums"));
			GenerateApiContext(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateITokenService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateIUploadLocalService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateRepositoryCreateRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryDeleteRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryGetAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryGetRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryIsExistRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryListAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryListRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryPaginationAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryPaginationRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositorySoftDeleteRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryUpdateRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateGetClientTokenRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenerateGetClientTokenResult(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenerateGetTokenRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenereateGetTokenResponse(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenerateValidateTokenRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenerateExceptionHelper(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Enums"));
			GenerateMultiLanguageFormFile(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "JsonModels"));
			GenerateMultiLanguageListString(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "JsonModels"));
			GenerateMultiLanguageString(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "JsonModels"));
		}

		private void GenerateIRepository(string projectName, string outputFilePath)
		{

			GeneratorModel generateIRepositoryModel = new()
			{
				NamespaceNameDefault = projectName+".Services",
				ClassNameDefault = "IRepository",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\CreateIRepository.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName,
				Methods = new Dictionary<string, string>
				{
					{"InsertAsync", "void" },
					{"Update", "void" },
					{"Delete", "void" },
					{"GetAsync", "Task<T>?" }
				}
			};

			_generator.GenerateClass(generateIRepositoryModel);
		}
		private void GenerateIBaseEntity(string projectName, string outputFilePath)
		{
			GeneratorModel generateIBaseEntity = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "IBaseEntity",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\CreateIBaseEntity.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName= projectName
			};

			_generator.GenerateClass(generateIBaseEntity);
		}
		private void GenerateIUnitOfWork(string projectName, string outputFilePath)
		{
			GeneratorModel generateIUnitOfWork = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "IUnitOfWork",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\CreateIUnitOfWork.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateIUnitOfWork);
		}
		private void GenerateUnitOfWorkResponse(string projectName, string outputFilePath)
		{
			GeneratorModel generateUnitOfWorkResponse = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "UnitOfWorkResponse",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\CreateUnitOfWorkResponse.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateUnitOfWorkResponse);
		}
		private void GeneratePaginationRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generatePaginationRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "PaginationRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\PaginationRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatePaginationRequest);
		}
		private void GeneratePaginationResponse(string projectName, string outputFilePath)
		{
			GeneratorModel generatePaginationResponse = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "PaginationResponse",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\PaginationResponse.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatePaginationResponse);
		}
		private void GenerateISmsNetGsmService(string projectName, string outputFilePath)
		{
			GeneratorModel generateISmsNewGsmService = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "ISmsNetGsmService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\ISmsNetGsmService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateISmsNewGsmService);
		}
		private void GenerateSmsNetGsmSendData(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmsNetGsmSendData = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "SmsNetGsmSendData",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\SmsNetGsmSendData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateSmsNetGsmSendData);
		}
		private void GenerateIEmailService(string projectName, string outputFilePath)
		{
			GeneratorModel generateIEmailService = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "IEmailService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\IEmailService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateIEmailService);
		}
		private void GenerateEmailSendData(string projectName, string outputFilePath)
		{
			GeneratorModel generateEmailSendData = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "EmailSendData",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\EmailSendData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateEmailSendData);
		}
		private void GenerateIMemoryCache(string projectName, string outputFilePath)
		{
			GeneratorModel generateIMemoryCache = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "IMemoryCacheService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\IMemoryCache.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateIMemoryCache);
		}
		private void GenerateDbEntityState(string projectName, string outputFilePath)
		{
			GeneratorModel generatedbEntityState = new()
			{
				NamespaceNameDefault = projectName + ".Enums",
				ClassNameDefault = "DbEntityState",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Enums\\DbEntityState.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatedbEntityState);
		}
		private void GenerateApiContext(string projectName, string outputFilePath)
		{
			GeneratorModel generateApiContext = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "ApiContext",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\ApiContext.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateApiContext);
		}
		private void GenerateITokenService(string projectName, string outputFilePath)
		{
			GeneratorModel generateITokenService = new()
			{
				NamespaceNameDefault = projectName + ".Services.TokenService",
				ClassNameDefault = "ITokenService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\TokenService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateITokenService);
		}
		private void GenerateRepositoryCreateRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "RepositoryCreateRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryCreateRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRequest);
		}
		private void GenerateRepositoryDeleteRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryDeleteRequest = new()
			{
				NamespaceNameDefault = projectName + ".RepositoryModels",
				ClassNameDefault = "RepositoryDeleteRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryDeleteRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryDeleteRequest);
		}
		private void GenerateRepositoryGetAsTResultRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryGetAsTResultRequest = new()
			{
				NamespaceNameDefault =  projectName+ ".RepositoryModels",
				ClassNameDefault = "RepositoryGetAsTResultRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryGetAsTResultRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryGetAsTResultRequest);
		}
		private void GenerateRepositoryGetRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryGetRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryGetRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryGetRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryGetRequest);
		}
		private void GenerateRepositoryIsExistRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryIsExistRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryIsExistRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryIsExistRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryIsExistRequest);
		}
		private void GenerateRepositoryListAsTResultRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generatorModel = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryListAsTResultRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryListAsTResultRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatorModel);
		}
		private void GenerateRepositoryListRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryListRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryListRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryListRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryListRequest);
		}
		private void GenerateRepositoryPaginationAsTResultRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryPaginationsAsTResultRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryPaginationAsTResultRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryPaginationAsTResultRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryPaginationsAsTResultRequest);
		}
		private void GenerateRepositoryPaginationRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryPaginationsRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryPaginationRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryPaginationRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryPaginationsRequest);
		}
		private void GenerateRepositorySoftDeleteRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositorySoftDeleteRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositorySoftDeleteRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositorySoftDeleteRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositorySoftDeleteRequest);
		}
		private void GenerateRepositoryUpdateRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryUpdateRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryUpdateRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\RepositoryModels\\RepositoryUpdateRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryUpdateRequest);
		}
		private void GenerateGetClientTokenRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateGetClientTokenRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "GetClientTokenRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\TokenModels\\GetClientTokenRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateGetClientTokenRequest);
		}
		private void GenerateGetClientTokenResult(string projectName, string outputFilePath)
		{
			GeneratorModel generateGetClientTokenResult = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "GetClientTokenResult",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\TokenModels\\GetClientTokenResult.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateGetClientTokenResult);
		}
		private void GenerateGetTokenRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateaGetTokenRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "GetTokenRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\TokenModels\\GetTokenRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateaGetTokenRequest);
		}
		private void GenereateGetTokenResponse(string projectName, string outputFilePath)
		{
			GeneratorModel genereateGetTokenResponse = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "GetTokenResponse",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\TokenModels\\GetTokenResponse.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(genereateGetTokenResponse);
		}
		private void GenerateValidateTokenRequest(string projectName, string outputFilePath)
		{
			GeneratorModel validateTokenRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "ValidateTokenRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\TokenModels\\ValidateTokenRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(validateTokenRequest);
		}
		private void GenerateExceptionHelper(string projectName, string outputFilePath) 
		{
			GeneratorModel exceptionHelper = new()
			{
				NamespaceNameDefault = projectName + ".Helpers",
				ClassNameDefault = "ExceptionHelper",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Helpers\\ExceptionHelper.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(exceptionHelper);
		}
		private void GenerateMultiLanguageFormFile(string projectName, string outputFilePath)
		{
			GeneratorModel generateFormFile = new()
			{
				NamespaceNameDefault = projectName + ".Core.JsonModels",
				ClassNameDefault = "MultiLanguageFormFile",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\JsonHelpers\\MultiLanguageFormFile.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateFormFile);
		}
		private void GenerateMultiLanguageListString(string projectName, string outputFilePath) 
		{
			GeneratorModel generateListString = new()
			{
				NamespaceNameDefault = projectName + ".Core.JsonModels",
				ClassNameDefault = "MultiLanguageListString",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\JsonHelpers\\MultiLanguageListString.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateListString);
		}
		private void GenerateMultiLanguageString(string projectName, string outputFilePath)
		{
			GeneratorModel generateString = new()
			{
				NamespaceNameDefault = projectName + ".Core.JsonModels",
				ClassNameDefault = "MultiLanguageString",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\JsonHelpers\\MultiLanguageString.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateString);
				
		}
		private void GenerateIUploadLocalService(string projectName, string outputFilePath)
		{
			GeneratorModel generateService = new()
			{
				NamespaceNameDefault = projectName + ".Core.Services",
				ClassNameDefault = "IUploadLocalService",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\IUploadLocalService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateService);
		}
	}
}