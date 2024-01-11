using ViFactory.Models;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;

namespace ViFactory.Services.Core
{
    /// <summary>
    /// Constant Classes Created
    /// </summary>
    /// <param name="projectName"></param>
    /// <param name="outputFilePath"></param>
    public class CoreGenerator : ICoreGenerator
	{
		private readonly IGenerator _generator;
		private readonly IProjectGenerator _projectGenerator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CoreGenerator(IGenerator generator, IProjectGenerator projectGenerator, IWebHostEnvironment webHostEnvironment)
        {
            _generator = generator;
            _projectGenerator = projectGenerator;
            _webHostEnvironment = webHostEnvironment;
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
			GenerateEmailSendData(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateDbEntityState(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Enums"));
			GenerateApiContext(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			GenerateITokenService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateIUploadLocalService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
			GenerateRepositoryCreateRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryDeleteRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryGetAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryGetRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryListAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryListRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryPaginationAsTResultRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryPaginationRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateRepositoryUpdateRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
            GenerateRepositoryAnyRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
            GenerateRepositoryCreateBulkRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
            GenerateRepositoryFindRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
            GenerateRepositoryUpdateBulkRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "RepositoryModels"));
			GenerateGetTokenRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenereateGetTokenResponse(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
			GenerateValidateTokenRequest(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "TokenModels"));
            GenerateExceptionExtension(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Extensions"));
            GenerateISmtpService(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Services"));
            GenerateSmtpSendData(projectGeneratorModel.ProjectName, Path.Combine(projectGeneratorModel.OutputFolderPath, projectGeneratorModel.ProjectName, "Models"));
			
		}
		private void GenerateIRepository(string projectName, string outputFilePath)
		{

			GeneratorModel generateIRepositoryModel = new()
			{
				NamespaceNameDefault = projectName+".Services",
				ClassNameDefault = "IRepository",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Services\\CreateIRepository.txt",
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
		private void GenerateIUnitOfWork(string projectName, string outputFilePath)
		{
			GeneratorModel generateIUnitOfWork = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "IUnitOfWork",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Services\\CreateIUnitOfWork.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateIUnitOfWork);
		}
		private void GenerateISmtpService(string projectName, string outputFilePath) 
		{
			GeneratorModel generateISmtpService = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "ISmtpService",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Services\\ISmtpService.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
			_generator.GenerateClass(generateISmtpService);
		}
		private void GenerateITokenService(string projectName, string outputFilePath)
		{
			GeneratorModel generateITokenService = new()
			{
				NamespaceNameDefault = projectName + ".Services.TokenService",
				ClassNameDefault = "ITokenService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Services\\TokenService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateITokenService);
		}
        private void GenerateIUploadLocalService(string projectName, string outputFilePath)
        {
            GeneratorModel generateService = new()
            {
                NamespaceNameDefault = projectName + ".Services",
                ClassNameDefault = "IUploadLocalService",
                InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Services\\IUploadLocalService.txt",
                OutputFilePath = outputFilePath,
                CurrentProjectName = projectName
            };
            _generator.GenerateClass(generateService);
        }
		private void GenerateISmsNetGsmService(string projectName, string outputFilePath)
		{
			GeneratorModel generateISmsNewGsmService = new()
			{
				NamespaceNameDefault = projectName + ".Services",
				ClassNameDefault = "ISmsNetGsmService",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Services\\ISmsNetGsmService.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateISmsNewGsmService);
		}
		private void GenerateDbEntityState(string projectName, string outputFilePath)
		{
			GeneratorModel generatedbEntityState = new()
			{
				NamespaceNameDefault = projectName + ".Enums",
				ClassNameDefault = "DbEntityState",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Enums\\DbEntityState.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatedbEntityState);
		}
		private void GenerateIBaseEntity(string projectName, string outputFilePath)
		{
			GeneratorModel generateIBaseEntity = new GeneratorModel()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "IBaseEntity",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\CreateIBaseEntity.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName= projectName
			};

			_generator.GenerateClass(generateIBaseEntity);
		}
		private void GenerateUnitOfWorkResponse(string projectName, string outputFilePath)
		{
			GeneratorModel generateUnitOfWorkResponse = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "UnitOfWorkResponse",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\CreateUnitOfWorkResponse.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\PaginationRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\PaginationResponse.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generatePaginationResponse);
		}
		private void GenerateSmsNetGsmSendData(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmsNetGsmSendData = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "SmsNetGsmSendData",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\SmsNetGsmSendData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateSmsNetGsmSendData);
		}
		private void GenerateEmailSendData(string projectName, string outputFilePath)
		{
			GeneratorModel generateEmailSendData = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "EmailSendData",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\EmailSendData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateEmailSendData);
		}
		private void GenerateApiContext(string projectName, string outputFilePath)
		{
			GeneratorModel generateApiContext = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "ApiContext",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\ApiContext.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateApiContext);
		}
		private void GenerateSmtpSendData(string projectName, string outputFilePath)
		{
			GeneratorModel generateSmtpSendData = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "SmtpSendData",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Model\\SmtpSendData.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateSmtpSendData);

        }
		private void GenerateRepositoryCreateRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models",
				ClassNameDefault = "RepositoryCreateRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryCreateRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryDeleteRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryGetAsTResultRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryGetRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryGetRequest);
		}
		private void GenerateRepositoryListAsTResultRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generatorModel = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryListAsTResultRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryListAsTResultRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryListRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryPaginationAsTResultRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryPaginationRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryPaginationsRequest);
		}
		private void GenerateRepositoryUpdateRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryUpdateRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryUpdateRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\RepositoryModels\\RepositoryUpdateRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(generateRepositoryUpdateRequest);
		}
		private void GenerateRepositoryFindRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryFindRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryFindRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Model\\RepositoryModels\\RepositoryFindRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateRepositoryFindRequest);
        }
		private void GenerateRepositoryUpdateBulkRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateUpdateBulkRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryUpdateBulkRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Model\\RepositoryModels\\RepositoryUpdateBulkRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateUpdateBulkRequest);	
        }
		private void GenerateRepositoryAnyRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateRepositoryAnyRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryAnyRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Model\\RepositoryModels\\RepositoryAnyRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateRepositoryAnyRequest);
        }
		private void GenerateRepositoryCreateBulkRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateCreateBulkRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.RepositoryModels",
				ClassNameDefault = "RepositoryCreateBulkRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") + "\\Core\\Model\\RepositoryModels\\RepositoryCreateBulkRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};
			_generator.GenerateClass(generateCreateBulkRequest);
        }
		private void GenerateGetTokenRequest(string projectName, string outputFilePath)
		{
			GeneratorModel generateaGetTokenRequest = new()
			{
				NamespaceNameDefault = projectName + ".Models.TokenModels",
				ClassNameDefault = "GetTokenRequest",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\TokenModels\\GetTokenRequest.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\TokenModels\\GetTokenResponse.txt",
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
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Model\\TokenModels\\ValidateTokenRequest.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(validateTokenRequest);
		}
		private void GenerateExceptionExtension(string projectName, string outputFilePath) 
		{
			GeneratorModel exceptionHelper = new()
			{
				NamespaceNameDefault = projectName + ".Extensions",
				ClassNameDefault = "ExceptionExtensions",
				InputFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "template") +"\\Core\\Helpers\\ExceptionHelper.txt",
				OutputFilePath = outputFilePath,
				CurrentProjectName = projectName
			};

			_generator.GenerateClass(exceptionHelper);
		}
    }
}