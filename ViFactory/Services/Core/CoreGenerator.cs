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

			GenerateIRepository(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateIBaseEntity(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GenerateIUnitOfWork(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateUnitOfWorkResponse(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GeneratePaginationRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GeneratePaginationResponse(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GenerateISmsNetGsmService(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateSmsNetGsmSendData(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GenerateIEmailService(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateEmailSendData(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GenerateIMemoryCache(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateDbEntityState(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Enums\\");
			GenerateApiContext(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\");
			GenerateITokenService(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Services\\");
			GenerateRepositoryCreateRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryDeleteRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryGetAsTResultRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryGetRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryIsExistRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryListAsTResultRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryListRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryPaginationAsTResultRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryPaginationRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositorySoftDeleteRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateRepositoryUpdateRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\RepositoryModels\\");
			GenerateGetClientTokenRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\TokenModels\\");
			GenerateGetClientTokenResult(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\TokenModels\\");
			GenerateGetTokenRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\TokenModels\\");
			GenereateGetTokenResponse(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\TokenModels\\");
			GenerateValidateTokenRequest(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Models\\TokenModels\\");
			GenerateExceptionHelper(projectGeneratorModel.ProjectName, "C:\\Users\\ygmr4\\Desktop\\ViFactorySample\\ViFactorySample.Core\\Enums\\");
		}

		private void GenerateIRepository(string projectName, string outputFilePath)
		{

			GeneratorModel generateIRepositoryModel = new()
			{
				NamespaceNameDefault = projectName+".Services",
				ClassNameDefault = "IRepository",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\CreateIRepository.txt",
				OutputFilePath = outputFilePath,
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
			};

			_generator.GenerateClass(generateIUnitOfWork);
		}
		private void GenerateUnitOfWorkResponse(string projectName, string outputFilePath)
		{
			GeneratorModel generatUnitOfWorkResponse = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "UnitOfWorkResponse",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\CreateUnitOfWorkResponse.txt",
				OutputFilePath = outputFilePath
			};

			_generator.GenerateClass(generatUnitOfWorkResponse);
		}
		private void GeneratePaginationRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generatePaginationRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "PaginationRequest",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Model\\PaginationRequest.txt",
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
			};
			_generator.GenerateClass(generateEmailSendData);
		}
		private void GenerateIMemoryCache(string projectName, string outputFilePath)
		{
			GeneratorModel generateIMemoryCache = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "IMemoryCache",
				InputFilePath = "C:\\Users\\ygmr4\\Desktop\\ViFactory\\ViFactory\\Texts\\Core\\Services\\IMemoryCache.txt",
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath 
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
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
				OutputFilePath = outputFilePath
			};
			_generator.GenerateClass(exceptionHelper);
		}
	}
}